using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Polly;
using Tgs.GameInterface.Awc.Core;
using Tgs.GameInterface.Awc.Core.Exceptions;
using Tgs.GameInterface.Awc.Core.Models;

namespace Tgs.GameInterface.Awc.Core;

internal class GameApiClient(
    ILogger<GameApiClient> logger,
    HttpClient client) : IGameApiClient
{
    private static readonly JsonSerializerOptions? _SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };

    public async ValueTask<bool> CheckTransferOperationAsync(Uri apiUrl, string agentId, string cert, string transactionId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["txCode"] = transactionId
        };

        var jsonNode = await PostAsync(
           apiUrl: apiUrl,
           path: "/wallet/checkTransferOperation",
           parameters: parameters,
           logPrefix: "checkTransferOperation",
           cancellationToken: cancellationToken)
           .ConfigureAwait(false);

        var status = jsonNode["status"]!.GetValue<string>();

        if (!status.Equals(((int)GameApiClientError.Success).ToString("d4"), StringComparison.InvariantCultureIgnoreCase))
        {
            throw new StatusException(status);
        }

        var txStatus = jsonNode["txStatus"]!.GetValue<int>();

        return txStatus == 1;
    }

    public async ValueTask CreatePlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string language = "en", CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["userId"] = playerCode,
            ["currency"] = currency,
            ["betLimit"] = string.Empty,
            ["language"] = language,
            ["userName"] = userName,
        };

        var jsonNode = await PostAsync(
            apiUrl: apiUrl,
            path: "/wallet/createMember",
            parameters: parameters,
            logPrefix: "createMember",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var status = jsonNode["status"]!.GetValue<string>();

        if (!status.Equals(((int)GameApiClientError.Success).ToString("d4"), StringComparison.InvariantCultureIgnoreCase))
        {
            if (!status.Equals(((int)GameApiClientError.AccountExisted).ToString("d4"), StringComparison.InvariantCultureIgnoreCase))
            {
                throw new StatusException(status);
            }
        }
    }

    public async ValueTask CreatePlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string betLimit, string language = "en", CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["userId"] = playerCode,
            ["currency"] = currency,
            ["betLimit"] = betLimit,
            ["language"] = language,
            ["userName"] = userName,
        };

        var jsonNode = await PostAsync(
            apiUrl: apiUrl,
            path: "/wallet/createMember",
            parameters: parameters,
            logPrefix: "createMember",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var status = jsonNode["status"]!.GetValue<string>();

        if (!status.Equals(((int)GameApiClientError.Success).ToString("d4"), StringComparison.InvariantCultureIgnoreCase))
        {
            if (!status.Equals(((int)GameApiClientError.AccountExisted).ToString("d4"), StringComparison.InvariantCultureIgnoreCase))
            {
                throw new StatusException(status);
            }
        }
    }

    public async ValueTask<FundResp> DepositAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["userId"] = playerCode,
            ["txCode"] = transactionId,
            ["transferAmount"] = amount.ToString()
        };

        var tryCount = 3;
        var seconds = 2;
        var retryPolicy = Policy.HandleResult<JsonNode>(
            jsonNode =>
            {
                var status = jsonNode["status"]!.GetValue<string>();
                return status == ((int)GameApiClientError.UnableToProceedPleaseTryAgainLater).ToString("d4");
            })
            .WaitAndRetryAsync(
            retryCount: tryCount,
            retryAttempt => TimeSpan.FromSeconds(seconds),
            (result, retryTime, context) =>
            {
                logger.LogWarning("LogOn:{logOn}  Parameter:{parameters} Result:{result} Delay:{retryTime}",
                    DateTime.Now.ToString("o"),
                    JsonSerializer.Serialize(parameters),
                    JsonSerializer.Serialize(result),
                    retryTime);
            });

        var jsonNode = await retryPolicy.ExecuteAsync(
            async () => await PostAsync(
                apiUrl: apiUrl,
                path: "/wallet/deposit",
                parameters: parameters,
                logPrefix: "deposit",
                cancellationToken: cancellationToken)
            .ConfigureAwait(false))
            .ConfigureAwait(false);

        var status = jsonNode["status"]!.GetValue<string>();

        return !status.Equals(((int)GameApiClientError.Success).ToString("d4"), StringComparison.InvariantCultureIgnoreCase)
            ? throw new StatusException(status)
            : new FundResp(
                TransactionId: jsonNode["txCode"]!.ToString(),
                GameProviderTransactionId: jsonNode["databaseId"]!.ToString(),
                Amount: decimal.Parse(jsonNode["amount"]!.ToString()),
                CurrentBalance: decimal.Parse(jsonNode["currentBalance"]!.ToString()),
                Resp: jsonNode.ToJsonString());
    }

    public async IAsyncEnumerable<BalanceInfo> GetAllBalancesAsync(Uri apiUrl, string agentId, string cert, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["isFilterBalance"] = 1.ToString(),
            ["alluser"] = 1.ToString()
        };

        var jsonNode = await PostAsync(
            apiUrl: apiUrl,
            path: "/wallet/getBalance",
            parameters: parameters,
            logPrefix: "getAllBalances",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var status = jsonNode["status"]!.GetValue<string>();

        if (status != ((int)GameApiClientError.Success).ToString("d4"))
        {
            throw new StatusException(status);
        }

        var balances = jsonNode["results"]!.AsArray();

        if (balances.Count == 0)
        {
            yield break;
        }

        foreach (var balance in balances)
        {
            if (balance is null)
            {
                continue;
            }

            yield return new BalanceInfo(
                UserId: balance["userId"]!.ToString(),
                Balance: decimal.Parse(balance["balance"]!.ToString()),
                LastModified: balance["lastModified"]!.GetValue<DateTimeOffset>());
        }
    }

    public async ValueTask<GetBalanceResp> GetBalanceAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["alluser"] = 0.ToString(),
            ["userIds"] = playerCode,
        };

        var jsonNode = await PostAsync(
            apiUrl: apiUrl,
            path: "/wallet/getBalance",
            parameters: parameters,
            logPrefix: "getBalance",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var status = jsonNode["status"]!.GetValue<string>();

        if (status != ((int)GameApiClientError.Success).ToString("d4"))
        {
            return status == ((int)GameApiClientError.AccountIsNotExists).ToString("d4")
                ? new GetBalanceResp(
                    IsPlayerExist: false,
                    Balance: 0)
                : throw new StatusException(status);
        }

        var result = jsonNode["results"]!.AsArray()
            .Where(x => x!["userId"]!.ToString().Equals(playerCode, StringComparison.InvariantCultureIgnoreCase))
            .FirstOrDefault();

        return result is null
            ? new GetBalanceResp(
                IsPlayerExist: false,
                Balance: 0)
            : new GetBalanceResp(
                IsPlayerExist: true,
                Balance: decimal.Parse(result!["balance"]!.ToString()));
    }

    public ValueTask<LoginAndLaunchGameResult> LoginAndLaunchGameAsync(Uri apiUrl, string agentId, string cert, LoginAndLaunchGame data, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["userId"] = data.PlayerCode,
            ["isMobileLogin"] = data.IsMobileLogin.ToString(),
            ["externalURL"] = data.BackUrl,
            ["platform"] = data.Platform,
            ["gameType"] = data.GameType,
            ["gameCode"] = data.ExternalGameId,
            ["language"] = data.Language
        };

        return LoginAndLaunchGameAsync(apiUrl, parameters, cancellationToken);
    }

    public ValueTask<LoginAndLaunchGameResult> LoginAndLaunchGameAsync(Uri apiUrl, string agentId, string cert, LoginAndLaunchGameByLive data, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["userId"] = data.PlayerCode,
            ["isMobileLogin"] = data.IsMobileLogin.ToString(),
            ["externalURL"] = data.BackUrl,
            ["platform"] = data.Platform,
            ["gameType"] = AwcGameTypes.LIVE.ToString(),
            ["gameCode"] = data.ExternalGameId,
            ["language"] = data.Language,
            ["betLimit"] = data.BetLimit
        };

        return LoginAndLaunchGameAsync(apiUrl, parameters, cancellationToken);
    }

    public async ValueTask LogoutAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["userIds"] = playerCode,
        };

        var tryCount = 3;
        var seconds = 2;
        var retryPolicy = Policy.HandleResult<JsonNode>(
            jsonNode =>
            {
                var status = jsonNode["status"]!.GetValue<string>();
                return status == ((int)GameApiClientError.UnableToProceedPleaseTryAgainLater).ToString("d4");
            })
            .WaitAndRetryAsync(
            retryCount: tryCount,
            retryAttempt => TimeSpan.FromSeconds(seconds),
            (result, retryTime, context) =>
            {
                logger.LogWarning("LogOn:{logOn}  Parameter:{parameters} Result:{result} Delay:{retryTime}",
                    DateTime.Now.ToString("o"),
                    JsonSerializer.Serialize(parameters),
                    JsonSerializer.Serialize(result),
                    retryTime);
            });

        var jsonNode = await retryPolicy.ExecuteAsync(
            async () => await PostAsync(
                apiUrl: apiUrl,
                path: "/wallet/logout",
                parameters: parameters,
                logPrefix: "logout",
                cancellationToken: cancellationToken)
            .ConfigureAwait(false))
            .ConfigureAwait(false);

        var status = jsonNode["status"]!.GetValue<string>();

        if (status != ((int)GameApiClientError.Success).ToString("d4"))
        {
            throw new StatusException(status);
        }
    }

    public async ValueTask<FundResp> WithdrawAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, int withdrawType = 0, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["userId"] = playerCode,
            ["withdrawType"] = withdrawType.ToString(),
            ["txCode"] = transactionId,
            ["transferAmount"] = amount.ToString()
        };

        var tryCount = 3;
        var seconds = 2;
        var retryPolicy = Policy.HandleResult<JsonNode>(
            jsonNode =>
            {
                var status = jsonNode["status"]!.GetValue<string>();
                return status == ((int)GameApiClientError.UnableToProceedPleaseTryAgainLater).ToString("d4");
            })
            .WaitAndRetryAsync(
            retryCount: tryCount,
            retryAttempt => TimeSpan.FromSeconds(seconds),
            (result, retryTime, context) =>
            {
                logger.LogWarning("LogOn:{logOn}  Parameter:{parameters} Result:{result} Delay:{retryTime}",
                    DateTime.Now.ToString("o"),
                    JsonSerializer.Serialize(parameters),
                    JsonSerializer.Serialize(result),
                    retryTime);
            });

        var jsonNode = await retryPolicy.ExecuteAsync(
            async () => await PostAsync(
                apiUrl: apiUrl,
                path: "/wallet/withdraw",
                parameters: parameters,
                logPrefix: "withdraw",
                cancellationToken: cancellationToken)
            .ConfigureAwait(false))
            .ConfigureAwait(false);

        var status = jsonNode["status"]!.GetValue<string>();

        return !status.Equals(((int)GameApiClientError.Success).ToString("d4"), StringComparison.InvariantCultureIgnoreCase)
            ? throw new StatusException(status)
            : new FundResp(
                TransactionId: jsonNode["txCode"]!.ToString(),
                GameProviderTransactionId: jsonNode["databaseId"]!.ToString(),
                Amount: decimal.Parse(jsonNode["amount"]!.ToString()),
                CurrentBalance: decimal.Parse(jsonNode["currentBalance"]!.ToString()),
                Resp: jsonNode.ToJsonString());
    }

    private async ValueTask<LoginAndLaunchGameResult> LoginAndLaunchGameAsync(Uri apiUrl, IEnumerable<KeyValuePair<string, string>> parameters, CancellationToken cancellationToken = default)
    {
        var tryCount = 3;
        var seconds = 1;
        var retryPolicy = Policy.HandleResult<JsonNode>(
            jsonNode =>
            {
                var status = jsonNode["status"]!.GetValue<string>();
                return status == ((int)GameApiClientError.UnableToProceedPleaseTryAgainLater).ToString("d4");
            })
            .WaitAndRetryAsync(
            retryCount: tryCount,
            retryAttempt => TimeSpan.FromSeconds(seconds),
            (result, retryTime, context) =>
            {
                logger.LogWarning("LogOn:{logOn}  Parameter:{parameters} Result:{result} Delay:{retryTime}",
                    DateTime.Now.ToString("o"),
                    parameters,
                    result,
                    retryTime);
            });

        var jsonNode = await retryPolicy.ExecuteAsync(
            async () => await PostAsync(
                apiUrl: apiUrl,
                path: "/wallet/doLoginAndLaunchGame",
                parameters: parameters,
                logPrefix: "GetGamingLoginGameAsync",
                cancellationToken: cancellationToken)
            .ConfigureAwait(false))
            .ConfigureAwait(false);

        var status = jsonNode["status"]!.GetValue<string>();

        return status != ((int)GameApiClientError.Success).ToString("d4")
            ? status == ((int)GameApiClientError.AccountIsNotExists).ToString("d4")
                ? new LoginAndLaunchGameResult(
                    IsPlayerExist: false,
                    GameUrl: string.Empty)
                : throw new StatusException(status)
            : new LoginAndLaunchGameResult(
                IsPlayerExist: true,
                GameUrl: jsonNode["url"]!.ToString());
    }

    private async ValueTask<JsonNode> PostAsync(Uri apiUrl, string path, IEnumerable<KeyValuePair<string, string>> parameters, string logPrefix, CancellationToken cancellationToken = default)
    {
        logPrefix = $"{nameof(GameApiClient)}.{logPrefix}".ToLower();

        var sw = Stopwatch.StartNew();
        var url = new Uri(apiUrl, path);

        HttpContent content = new FormUrlEncodedContent(parameters);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded")
        {
            CharSet = "UTF-8"
        };

        var httpResponseMessage = await client.PostAsync(
            requestUri: url,
            content: content,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        sw.Stop();

        var responseMessage = default(string);

        using (var sr = new StreamReader(httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken).Result))
        {
            responseMessage = await sr.ReadToEndAsync(
                cancellationToken: cancellationToken)
                .ConfigureAwait(false) ?? string.Empty;
        }

        var apiLogEvent = new GameApiLogEvent
        {
            Path = httpResponseMessage.RequestMessage?.RequestUri?.AbsoluteUri.NoLongerThan(512) ?? string.Empty,
            Method = httpResponseMessage.RequestMessage?.Method.ToString().NoLongerThan(8) ?? string.Empty,
            Prefix = logPrefix,
            ServerName = Environment.MachineName.NoLongerThan(128),
            RequestHeaders = httpResponseMessage.RequestMessage?.Headers + httpResponseMessage.RequestMessage?.Content?.Headers?.ToString(),
            RequestContent = (await content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false)).NoLongerThan(4096),
            ResponseHeaders = httpResponseMessage.Headers.ToString(),
            ResponseContent = responseMessage.NoLongerThan(4096),
            ResponseCode = (short)httpResponseMessage.StatusCode,
            ExecutionTimeMs = (int)sw.ElapsedMilliseconds,
            RecordedOn = DateTimeOffset.UtcNow
        };
        logger.LogInformation("{apiLogEvent}", JsonSerializer.Serialize(apiLogEvent));

        _ = httpResponseMessage.EnsureSuccessStatusCode();

        return JsonNode.Parse(responseMessage)!;
    }
}
