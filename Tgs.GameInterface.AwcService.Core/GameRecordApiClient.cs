using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Polly;
using Tgs.GameInterface.AwcService.Core.Exceptions;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core;

internal class GameRecordApiClient : IGameRecordApiClient
{
    private static readonly JsonSerializerOptions? _SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };

    private readonly HttpClient _client;
    private readonly ILogger<GameRecordApiClient> _logger;

    public GameRecordApiClient(
        ILogger<GameRecordApiClient> logger,
        HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async IAsyncEnumerable<GetOutstandingByBetTimeTransaction> GetOutstandingByBetTimeAsync(Uri apiUrl, string agentId, string cert, string platform, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["startTime"] = startTime.ToIso8601String(),
            ["endTime"] = endTime.ToIso8601String(),
            ["platform"] = platform
        };

        var retryPolicy = Policy
            .HandleResult<JsonNode>(jsonNode =>
            {
                var status = jsonNode["status"]!.GetValue<string>();
                return status == ((int)GameApiClientError.UnableToProceedPleaseTryAgainLater).ToString("d4");
            })
            .WaitAndRetryAsync(
            retryCount: 2,
            retryAttempt =>
            {
                _logger.LogWarning("LogOn:{logOn} Attempt... {retryAttempt}", DateTime.Now.ToString("o"), retryAttempt);
                _logger.LogWarning("LogOn:{logOn} parameters: {parameters}", DateTime.Now.ToString("o"), parameters);
                var timeToRetry = TimeSpan.FromSeconds(Random.Shared.Next(20, 60));
                _logger.LogWarning("LogOn:{logOn} Waiting {timeToRetry} seconds", DateTime.Now.ToString("o"), timeToRetry.TotalSeconds);
                return timeToRetry;
            },
            (result, retryTime, context) =>
            {
                _logger.LogWarning("LogOn:{logOn}  Parameter:{parameters} Result:{result} Delay:{retryTime}",
                    DateTime.Now.ToString("o"),
                    parameters,
                    result,
                    retryTime);
            });

        var jsonNode = await retryPolicy.ExecuteAsync(
            async () => await PostAsync(
                apiUrl: apiUrl,
                path: "/fetch/gzip/getOutstandingByBetTime",
                parameters: parameters,
                logPrefix: "getOutstandingByBetTime",
                cancellationToken: cancellationToken)
            .ConfigureAwait(false))
            .ConfigureAwait(false);

        var status = jsonNode["status"]!.GetValue<string>();

        if (status != ((int)GameApiClientError.Success).ToString("d4"))
        {
            throw new StatusException(status);
        }

        var transactions = jsonNode["transactions"]!.AsArray();

        if (!transactions.Any())
        {
            yield break;
        }

        foreach (var transaction in transactions)
        {
            if (transaction is null)
            {
                continue;
            }

            yield return new GetOutstandingByBetTimeTransaction
            {
                PlatformTxId = transaction["platformTxId"]!.ToString(),
                GameType = transaction["gameType"]!.ToString(),
                GameCode = transaction["gameCode"]!.ToString(),
                GameName = transaction["gameName"]!.ToString(),
                RoundId = transaction["roundId"]!.ToString(),
                UserId = transaction["userId"]!.ToString(),
                Currency = transaction["currency"]!.ToString(),
                BetTime = transaction["betTime"]!.ToString(),
                BetType = transaction["betType"]?.ToString() ?? string.Empty,
                BetAmount = transaction["betAmount"]!.GetValue<decimal>(),
                RealBetAmount = transaction["realBetAmount"]!.GetValue<decimal>(),
                JackpotBetAmount = transaction["jackpotBetAmount"]!.GetValue<decimal>(),
                GameInfo = transaction["gameInfo"]!.ToString(),
                AdditionalData = transaction.ToJsonString()
            };
        }
    }

    public async IAsyncEnumerable<GetTransactionByTxTimeTransaction> GetTransactionByTxTimeAsync(Uri apiUrl, string agentId, string cert, string platform, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["startTime"] = startTime.ToIso8601String(),
            ["endTime"] = endTime.ToIso8601String(),
            ["platform"] = platform
        };

        var retryPolicy = Policy
            .HandleResult<JsonNode>(jsonNode =>
            {
                var status = jsonNode["status"]!.GetValue<string>();
                return status == ((int)GameApiClientError.UnableToProceedPleaseTryAgainLater).ToString("d4");
            })
            .WaitAndRetryAsync(
            retryCount: 2,
            retryAttempt =>
            {
                _logger.LogWarning("LogOn:{logOn} Attempt... {retryAttempt}", DateTime.Now.ToString("o"), retryAttempt);
                _logger.LogWarning("LogOn:{logOn} parameters: {parameters}", DateTime.Now.ToString("o"), parameters);
                var timeToRetry = TimeSpan.FromSeconds(Random.Shared.Next(20, 60));
                _logger.LogWarning("LogOn:{logOn} Waiting {timeToRetry} seconds", DateTime.Now.ToString("o"), timeToRetry.TotalSeconds);
                return timeToRetry;
            },
            (result, retryTime, context) =>
            {
                _logger.LogWarning("LogOn:{logOn} Parameter:{parameters} Result:{result} Delay:{retryTime}",
                    DateTime.Now.ToString("o"),
                    parameters,
                    result,
                    retryTime);
            });

        var jsonNode = await retryPolicy.ExecuteAsync(
            async () => await PostAsync(
            apiUrl: apiUrl,
            path: "/fetch/gzip/getTransactionByTxTime",
            parameters: parameters,
            logPrefix: "getTransactionByTxTime",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false))
            .ConfigureAwait(false); ;

        var status = jsonNode["status"]!.GetValue<string>();

        if (status != ((int)GameApiClientError.Success).ToString("d4"))
        {
            throw new StatusException(status);
        }

        var transactions = jsonNode["transactions"]!.AsArray();

        if (!transactions.Any())
        {
            yield break;
        }

        foreach (var transaction in transactions)
        {
            if (transaction is null)
            {
                continue;
            }

            yield return new GetTransactionByTxTimeTransaction
            {
                Platform = transaction["platform"]!.ToString(),
                PlatformTxId = transaction["platformTxId"]!.ToString(),
                GameType = transaction["gameType"]!.ToString(),
                GameCode = transaction["gameCode"]!.ToString(),
                GameName = transaction["gameName"]!.ToString(),
                RoundId = transaction["roundId"]!.ToString(),
                UserId = transaction["userId"]!.ToString(),
                Currency = transaction["currency"]!.ToString(),
                TxStatus = transaction["txStatus"]!.GetValue<int>(),
                SettleStatus = transaction["settleStatus"]!.GetValue<int>(),
                BetTime = transaction["betTime"]!.ToString(),
                TxTime = transaction["txTime"]!.ToString(),
                UpdateTime = transaction["updateTime"]!.ToString(),
                BetType = transaction["betType"]?.ToString() ?? string.Empty,
                BetAmount = transaction["betAmount"]!.GetValue<decimal>(),
                RealBetAmount = transaction["realBetAmount"]!.GetValue<decimal>(),
                Turnover = transaction["turnover"]!.GetValue<decimal>(),
                WinAmount = transaction["winAmount"]!.GetValue<decimal>(),
                RealWinAmount = transaction["realWinAmount"]!.GetValue<decimal>(),
                JackpotBetAmount = transaction["jackpotBetAmount"]!.GetValue<decimal>(),
                JackpotWinAmount = transaction["jackpotWinAmount"]!.GetValue<decimal>(),
                GameInfo = transaction["gameInfo"]!.ToString(),
                AdditionalData = transaction.ToJsonString()
            };
        }
    }

    public async IAsyncEnumerable<GetTransactionByUpdateDateTransaction> GetTransactionByUpdateDateAsync(Uri apiUrl, string agentId, string cert, string platform, DateTimeOffset timeFrom, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["timeFrom"] = timeFrom.ToIso8601String(),
            ["platform"] = platform
        };

        var retryPolicy = Policy
            .HandleResult<JsonNode>(jsonNode =>
            {
                var status = jsonNode["status"]!.GetValue<string>();
                return status == ((int)GameApiClientError.UnableToProceedPleaseTryAgainLater).ToString("d4");
            })
            .WaitAndRetryAsync(
            retryCount: 2,
            retryAttempt =>
            {
                _logger.LogWarning("LogOn:{logOn} Attempt... {retryAttempt}", DateTime.Now.ToString("o"), retryAttempt);
                _logger.LogWarning("LogOn:{logOn} parameters: {parameters}", DateTime.Now.ToString("o"), parameters);
                var timeToRetry = TimeSpan.FromSeconds(Random.Shared.Next(20, 60));
                _logger.LogWarning("LogOn:{logOn} Waiting {timeToRetry} seconds", DateTime.Now.ToString("o"), timeToRetry.TotalSeconds);
                return timeToRetry;
            },
            (result, retryTime, context) =>
            {
                _logger.LogWarning("LogOn:{logOn}  Parameter:{parameters} Result:{result} Delay:{retryTime}",
                    DateTime.Now.ToString("o"),
                    parameters,
                    result,
                    retryTime);
            });

        var jsonNode = await retryPolicy.ExecuteAsync(
            async () => await PostAsync(
                apiUrl: apiUrl,
                path: "/fetch/gzip/getTransactionByUpdateDate",
                parameters: parameters,
                logPrefix: "getTransactionByUpdateDate",
                cancellationToken: cancellationToken)
            .ConfigureAwait(false))
            .ConfigureAwait(false);

        var status = jsonNode["status"]!.GetValue<string>();

        if (status != ((int)GameApiClientError.Success).ToString("d4"))
        {
            throw new StatusException(status);
        }

        var transactions = jsonNode["transactions"]!.AsArray();

        if (!transactions.Any())
        {
            yield break;
        }

        foreach (var transaction in transactions)
        {
            if (transaction is null)
            {
                continue;
            }

            yield return new GetTransactionByUpdateDateTransaction
            {
                Platform = transaction["platform"]!.ToString(),
                PlatformTxId = transaction["platformTxId"]!.ToString(),
                GameType = transaction["gameType"]!.ToString(),
                GameCode = transaction["gameCode"]!.ToString(),
                GameName = transaction["gameName"]!.ToString(),
                RoundId = transaction["roundId"]!.ToString(),
                UserId = transaction["userId"]!.ToString(),
                Currency = transaction["currency"]!.ToString(),
                TxStatus = transaction["txStatus"]!.GetValue<int>(),
                SettleStatus = transaction["settleStatus"]!.GetValue<int>(),
                BetTime = transaction["betTime"]!.ToString(),
                TxTime = transaction["txTime"]!.ToString(),
                UpdateTime = transaction["updateTime"]!.ToString(),
                BetType = transaction["betType"]?.ToString() ?? string.Empty,
                BetAmount = transaction["betAmount"]!.GetValue<decimal>(),
                RealBetAmount = transaction["realBetAmount"]!.GetValue<decimal>(),
                Turnover = transaction["turnover"]!.GetValue<decimal>(),
                WinAmount = transaction["winAmount"]!.GetValue<decimal>(),
                RealWinAmount = transaction["realWinAmount"]!.GetValue<decimal>(),
                JackpotBetAmount = transaction["jackpotBetAmount"]!.GetValue<decimal>(),
                JackpotWinAmount = transaction["jackpotWinAmount"]!.GetValue<decimal>(),
                GameInfo = transaction["gameInfo"]!.ToString(),
                AdditionalData = transaction.ToJsonString()
            };
        }
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

        var httpResponseMessage = await _client.PostAsync(
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
        _logger.LogInformation("{apiLogEvent}", JsonSerializer.Serialize(apiLogEvent));

        _ = httpResponseMessage.EnsureSuccessStatusCode();

        return JsonNode.Parse(responseMessage)!;
    }
}
