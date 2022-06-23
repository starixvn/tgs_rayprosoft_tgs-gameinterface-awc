using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Polly;
using Tgs.GameInterface.AwcService.Core;
using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.GameInterface.AwcService.Repositories.Models;
using Tgs.Logging;

namespace Tgs.GameInterface.AwcService.Repositories
{
    internal class GameApiClient : IGameApiClient
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
        private readonly ILogger<GameApiClient> _logger;
        private readonly ITgsLog _tgsLog;

        public GameApiClient(
            HttpClient client,
            ILogger<GameApiClient> logger,
            ITgsLog tgsLog
            )
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tgsLog = tgsLog ?? throw new ArgumentNullException(nameof(tgsLog));
        }

        public async ValueTask<bool> CheckTransferOperationAsync(Uri apiUrl, string agentId, string cert, string transactionId, CancellationToken cancellationToken = default)
        {
            var parameters = new Dictionary<string, string>
            {
                ["cert"] = cert,
                ["agentId"] = agentId,
                ["txCode"] = transactionId
            };

            var document = await PostAsync(
               apiUrl,
               "/wallet/checkTransferOperation",
               parameters,
               "checkTransferOperation",
               cancellationToken).ConfigureAwait(false);

            if (document is null)
            {
                throw new Exception("Document is empty.");
            }

            var status = document.RootElement.GetProperty("status").GetString();

            if (status != ((int)GameApiClientError.Success).ToString("d4"))
            {
                throw new Exception($"This game manufacturer's transfer order number does not exist.({transactionId})");
            }

            var txStatus = document.RootElement.GetProperty("txStatus").GetInt32();

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

            var document = await PostAsync(
                apiUrl,
                "/wallet/createMember",
                parameters,
                "createMember",
                cancellationToken).ConfigureAwait(false);

            if (document is null)
            {
                throw new Exception("Document is empty.");
            }

            var status = document.RootElement.GetProperty("status").GetString();

            if (status != ((int)GameApiClientError.Success).ToString("d4") &&
                status != ((int)GameApiClientError.AccountExisted).ToString("d4"))
            {
                throw new Exception($"Failed to create player.({playerCode})");
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

            var document = await PostAsync(
                apiUrl,
                "/wallet/createMember",
                parameters,
                "createMember",
                cancellationToken).ConfigureAwait(false);

            if (document is null)
            {
                throw new Exception("Document is empty.");
            }

            var status = document.RootElement.GetProperty("status").GetString();

            if (status != ((int)GameApiClientError.Success).ToString("d4") &&
                  status != ((int)GameApiClientError.AccountExisted).ToString("d4")
                )
            {
                throw new Exception($"Failed to create player.({playerCode})");
            }
        }

        public async ValueTask<FundResult> DepositAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default)
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
            var retryPolicy = Policy.HandleResult<JsonDocument?>(r =>
            {
                var status = r?.RootElement.GetProperty("status").GetString();
                return status == ((int)GameApiClientError.UnableToProceedPleaseTryAgainLater).ToString("d4");
            })
             .WaitAndRetryAsync(tryCount,
                 retryAttempt => TimeSpan.FromSeconds(seconds),
                 (result, retryTime, context) =>
                 {
                     _logger.LogWarning("LogOn:{logOn}  Parameter:{parameters} Result:{result} Delay:{retryTime}",
                         DateTime.Now.ToString("o"),
                         JsonSerializer.Serialize(parameters),
                         JsonSerializer.Serialize(result),
                         retryTime);
                 });

            var document = await retryPolicy.ExecuteAsync(async () =>
            await PostAsync(
                apiUrl: apiUrl,
                path: "/wallet/deposit",
                parameters: parameters,
                logPrefix: "deposit",
                cancellationToken: cancellationToken)).ConfigureAwait(false);

            if (document is null)
            {
                throw new Exception("Document is empty.");
            }

            var status = document.RootElement.GetProperty("status").GetString();

            return status != ((int)GameApiClientError.Success).ToString("d4")
                ? new FundResult(
                    Success: false,
                    Message: document.RootElement.GetProperty("desc").ToString())
                : !document.RootElement.TryGetProperty("databaseId", out var jsonGameProductTransactionId) ||
                !document.RootElement.TryGetProperty("txCode", out var jsonTransactionId) ||
                !document.RootElement.TryGetProperty("currentBalance", out var jsonCurrentBalance) ||
                !document.RootElement.TryGetProperty("amount", out var jsonAmount)
                ? throw new Exception($"JsonElement parsing failed.({JsonSerializer.Serialize(document)})")
                : !decimal.TryParse(jsonAmount.GetString(), out var resultAmount) ||
                !decimal.TryParse(jsonCurrentBalance.GetString(), out var resultCurrentBalance)
                ? throw new Exception($"Decimal parsing failed.({JsonSerializer.Serialize(document)})")
                : new FundResult(
                Success: true,
                TransactionId: jsonTransactionId.ToString(),
                GameProviderTransactionId: jsonGameProductTransactionId.ToString(),
                Amount: resultAmount,
                CurrentBalance: resultCurrentBalance);
        }

        public async ValueTask<GetBalanceResult> GetBalanceAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default)
        {
            var parameters = new Dictionary<string, string>
            {
                ["cert"] = cert,
                ["agentId"] = agentId,
                ["alluser"] = 0.ToString(),
                ["userIds"] = playerCode,
            };

            var document = await PostAsync(
                apiUrl,
                "/wallet/getBalance",
                parameters,
                "getBalance",
                cancellationToken).ConfigureAwait(false);

            if (document is null)
            {
                throw new Exception("Document is empty.");
            }

            var status = document.RootElement.GetProperty("status").ToString();

            if (status == ((int)GameApiClientError.AccountIsNotExists).ToString("d4"))
            {
                return new GetBalanceResult(
                    Success: true,
                    Message: document.RootElement.GetProperty("desc").ToString(),
                    IsPlayerExist: false);
            }

            if (status != ((int)GameApiClientError.Success).ToString("d4"))
            {
                return new GetBalanceResult(
                    Success: false,
                    Message: document.RootElement.GetProperty("desc").ToString());
            }

            if (!document.RootElement.TryGetProperty(("results"), out JsonElement results))
            {
                throw new Exception("JsonElement parsing failed.");
            }
            var result = results.Deserialize<IEnumerable<BalanceModel>>(_SerializerOptions)!.FirstOrDefault(x => x.UserId == playerCode);

            return result == null
                ? new GetBalanceResult(Success: true)
                : new GetBalanceResult(
                Success: true,
                IsPlayerExist: true,
                Balance: decimal.Parse(result.Balance)
                );
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

        public ValueTask<LoginAndLaunchGameResult> LoginAndLaunchGameAsync(Uri apiUrl, string agentId, string cert, LoginAndLaunchGameByLiveLobby data, CancellationToken cancellationToken = default)
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
                ["language"] = data.Language,
                ["betLimit"] = data.BetLimit
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
            var retryPolicy = Policy.HandleResult<JsonDocument?>(r =>
            {
                var status = r?.RootElement.GetProperty("status").GetString();
                return status == ((int)GameApiClientError.UnableToProceedPleaseTryAgainLater).ToString("d4");
            })
             .WaitAndRetryAsync(tryCount,
                 retryAttempt => TimeSpan.FromSeconds(seconds),
                 (result, retryTime, context) =>
                 {
                     _logger.LogWarning("LogOn:{logOn}  Parameter:{parameters} Result:{result} Delay:{retryTime}",
                         DateTime.Now.ToString("o"),
                         JsonSerializer.Serialize(parameters),
                         JsonSerializer.Serialize(result),
                         retryTime);
                 });

            var document = await retryPolicy.ExecuteAsync(async () =>
            await PostAsync(
                 apiUrl: apiUrl,
                 path: "/wallet/logout",
                 parameters: parameters,
                 logPrefix: "logout",
                 cancellationToken: cancellationToken)).ConfigureAwait(false);

            if (document is null)
            {
                throw new Exception("Document is empty.");
            }

            var status = document.RootElement.GetProperty("status").GetString();

            if (status != ((int)GameApiClientError.Success).ToString("d4"))
            {
                throw new Exception($"The player has failed to kick the line.({playerCode}) |({JsonSerializer.Serialize(document)})");
            }
        }

        public async ValueTask<FundResult> WithdrawAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, int withdrawType = 0, CancellationToken cancellationToken = default)
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
            var retryPolicy = Policy.HandleResult<JsonDocument?>(r =>
            {
                var status = r?.RootElement.GetProperty("status").GetString();
                return status == ((int)GameApiClientError.UnableToProceedPleaseTryAgainLater).ToString("d4");
            })
             .WaitAndRetryAsync(tryCount,
                 retryAttempt => TimeSpan.FromSeconds(seconds),
                 (result, retryTime, context) =>
                 {
                     _logger.LogWarning("LogOn:{logOn}  Parameter:{parameters} Result:{result} Delay:{retryTime}",
                         DateTime.Now.ToString("o"),
                         JsonSerializer.Serialize(parameters),
                         JsonSerializer.Serialize(result),
                         retryTime);
                 });

            var document = await retryPolicy.ExecuteAsync(async () =>
            await PostAsync(
                apiUrl: apiUrl,
                path: "/wallet/withdraw",
                parameters: parameters,
                logPrefix: "withdraw",
                cancellationToken: cancellationToken)).ConfigureAwait(false);

            if (document is null)
            {
                throw new Exception("Document is empty.");
            }

            var status = document.RootElement.GetProperty("status").GetString();

            return status != ((int)GameApiClientError.Success).ToString("d4")
                ? new FundResult(
                    Success: false,
                    Message: document.RootElement.GetProperty("desc").ToString())
                : !document.RootElement.TryGetProperty("databaseId", out var jsonGameProductTransactionId) ||
                !document.RootElement.TryGetProperty("txCode", out var jsonTransactionId) ||
                !document.RootElement.TryGetProperty("currentBalance", out var jsonCurrentBalance) ||
                !document.RootElement.TryGetProperty("amount", out var jsonAmount)
                ? throw new Exception($"JsonElement parsing failed.({JsonSerializer.Serialize(document)})")
                : !decimal.TryParse(jsonAmount.GetString(), out var resultAmount) ||
                !decimal.TryParse(jsonCurrentBalance.GetString(), out var resultCurrentBalance)
                ? throw new Exception($"Decimal parsing failed.({JsonSerializer.Serialize(document)})")
                : new FundResult(
                Success: true,
                TransactionId: jsonTransactionId.ToString(),
                GameProviderTransactionId: jsonGameProductTransactionId.ToString(),
                Amount: resultAmount,
                CurrentBalance: resultCurrentBalance);
        }

        private async ValueTask<LoginAndLaunchGameResult> LoginAndLaunchGameAsync(Uri apiUrl, IEnumerable<KeyValuePair<string, string>> parameters, CancellationToken cancellationToken = default)
        {
            var tryCount = 3;
            var seconds = 1;
            var retryPolicy = Policy.HandleResult<JsonDocument?>(r =>
            {
                var status = r?.RootElement.GetProperty("status").GetString();
                return status == ((int)GameApiClientError.UnableToProceedPleaseTryAgainLater).ToString("d4");
            })
             .WaitAndRetryAsync(tryCount,
                 retryAttempt => TimeSpan.FromSeconds(seconds),
                 (result, retryTime, context) =>
                 {
                     _logger.LogWarning("LogOn:{logOn}  Parameter:{parameters} Result:{result} Delay:{retryTime}",
                         DateTime.Now.ToString("o"),
                         parameters,
                         result,
                         retryTime);
                 });

            var document = await retryPolicy.ExecuteAsync(async () =>
                await PostAsync(
                    apiUrl: apiUrl,
                    path: "/wallet/doLoginAndLaunchGame",
                    parameters: parameters,
                    logPrefix: "GetGamingLoginGameAsync",
                    cancellationToken: cancellationToken)).ConfigureAwait(false);

            if (document is null)
            {
                throw new Exception("Document is empty.");
            }

            var status = document.RootElement.GetProperty("status").ToString();

            return status == ((int)GameApiClientError.AccountIsNotExists).ToString("d4")
                ? new LoginAndLaunchGameResult(
                    Success: true)
                : status != ((int)GameApiClientError.Success).ToString("d4")
                ? new LoginAndLaunchGameResult(
                    Success: false,
                    Message: document.RootElement.GetProperty("desc").ToString())
                : !document.RootElement.TryGetProperty("url", out JsonElement jsonUrl)
                ? throw new Exception("JsonElement parsing failed.")
                : new LoginAndLaunchGameResult(
                    Success: true,
                    IsPlayerExist: true,
                    GameUrl: jsonUrl.GetString());
        }

        private async ValueTask<JsonDocument?> PostAsync(Uri apiUrl, string path, IEnumerable<KeyValuePair<string, string>> parameters, string logPrefix, CancellationToken cancellationToken = default)
        {
            logPrefix = $"{nameof(GameApiClient)}.{logPrefix}".ToLower();

            var sw = Stopwatch.StartNew();
            var url = new Uri(apiUrl, path);

            HttpContent content = new FormUrlEncodedContent(parameters);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded")
            {
                CharSet = "UTF-8"
            };

            var httpResponseMessage = await _client.PostAsync(url, content, cancellationToken);

            sw.Stop();

            var responseMessage = default(string);

            using (var sr = new StreamReader(httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken).Result))
            {
                responseMessage = await sr.ReadToEndAsync().ConfigureAwait(false) ?? string.Empty;
            }

            var apiLogEvent = new ApiLogEvent
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
            _tgsLog.LogApi(apiLogEvent);
            _logger.LogInformation("{apiLogEvent}", JsonSerializer.Serialize(apiLogEvent));

            _ = httpResponseMessage.EnsureSuccessStatusCode();

            return JsonDocument.Parse(responseMessage);
        }
    }
}
