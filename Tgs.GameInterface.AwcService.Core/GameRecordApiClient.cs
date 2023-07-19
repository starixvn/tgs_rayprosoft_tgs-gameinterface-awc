using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Polly;
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

    public async ValueTask<GetOutstandingByBetTimeResult> GetOutstandingByBetTimeAsync(Uri apiUrl, string agentId, string cert, string platform, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
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
            .HandleResult<JsonDocument?>(r =>
            {
                var status = r?.RootElement.GetProperty("status").GetString();
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

        var document = await retryPolicy
            .ExecuteAsync(
            async () =>
            await PostAsync(
                apiUrl: apiUrl,
                path: "/fetch/gzip/getOutstandingByBetTime",
                parameters: parameters,
                logPrefix: "getOutstandingByBetTime",
                cancellationToken: cancellationToken))
            .ConfigureAwait(false)
            ?? throw new Exception("Document is empty.");

        var status = document.RootElement.GetProperty("status").ToString();

        return
            status != ((int)GameApiClientError.Success).ToString("d4")
            ? new GetOutstandingByBetTimeResult(
                Success: false,
                Transactions: Enumerable.Empty<GetOutstandingByBetTimeTransaction>(),
                Message: document.RootElement.GetProperty("desc").ToString())
            : !document.RootElement.TryGetProperty(("transactions"), out JsonElement transactions)
            ? throw new Exception("JsonElement failed to parse transactions.")
            : new GetOutstandingByBetTimeResult(
            Success: true,
            Transactions: transactions.Deserialize<IEnumerable<GetOutstandingByBetTimeTransaction>>(_SerializerOptions)
            ?? Enumerable.Empty<GetOutstandingByBetTimeTransaction>());
    }

    public async ValueTask<GetTransactionByTxTimeResult> GetTransactionByTxTimeAsync(Uri apiUrl, string agentId, string cert, string platform, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
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
            .HandleResult<JsonDocument?>(r =>
            {
                var status = r?.RootElement.GetProperty("status").GetString();
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

        var document = await retryPolicy.ExecuteAsync(async () => await PostAsync(
            apiUrl: apiUrl,
            path: "/fetch/gzip/getTransactionByTxTime",
            parameters: parameters,
            logPrefix: "getTransactionByTxTime",
            cancellationToken: cancellationToken)).ConfigureAwait(false); ;

        if (document is null)
        {
            throw new Exception("Document is empty.");
        }

        var status = document.RootElement.GetProperty("status").ToString();

        return
            status != ((int)GameApiClientError.Success).ToString("d4")
            ? new GetTransactionByTxTimeResult(
                Success: false,
                Transactions: Enumerable.Empty<GetTransactionByTxTimeTransaction>(),
                Message: document.RootElement.GetProperty("desc").ToString())
            : !document.RootElement.TryGetProperty(("transactions"), out JsonElement transactions)
            ? throw new Exception("JsonElement failed to parse transactions.")
            : new GetTransactionByTxTimeResult(
            Success: true,
            Transactions: transactions.Deserialize<IEnumerable<GetTransactionByTxTimeTransaction>>(_SerializerOptions)
            ?? Enumerable.Empty<GetTransactionByTxTimeTransaction>());
    }

    public async ValueTask<GetTransactionByUpdateDateResult> GetTransactionByUpdateDateAsync(Uri apiUrl, string agentId, string cert, string platform, DateTimeOffset timeFrom, TransactionStatus transactionStatus, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["timeFrom"] = timeFrom.ToIso8601String(),
            ["platform"] = platform,
            ["status"] = ((int)transactionStatus).ToString()
        };

        var retryPolicy = Policy
            .HandleResult<JsonDocument?>(r =>
            {
                var status = r?.RootElement.GetProperty("status").GetString();
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

        var document = await retryPolicy.ExecuteAsync(
            async () =>
            await PostAsync(
                apiUrl: apiUrl,
                path: "/fetch/gzip/getTransactionByUpdateDate",
                parameters: parameters,
                logPrefix: "getTransactionByUpdateDate",
                cancellationToken: cancellationToken)
            .ConfigureAwait(false))
            ?? throw new Exception("Document is empty.");

        var status = document.RootElement.GetProperty("status").ToString();

        return
            status != ((int)GameApiClientError.Success).ToString("d4")
            ? new GetTransactionByUpdateDateResult(
                Success: false,
                Transactions: Enumerable.Empty<GetTransactionByUpdateDateTransaction>(),
                Message: document.RootElement.GetProperty("desc").ToString())
            : !document.RootElement.TryGetProperty(("transactions"), out JsonElement transactions)
            ? throw new Exception("JsonElement failed to parse transactions.")
            : new GetTransactionByUpdateDateResult(
            Success: true,
            Transactions: transactions.Deserialize<IEnumerable<GetTransactionByUpdateDateTransaction>>(_SerializerOptions)
            ?? Enumerable.Empty<GetTransactionByUpdateDateTransaction>());
    }

    public async ValueTask<GetTransactionByUpdateDateResult> GetTransactionByUpdateDateAsync(Uri apiUrl, string agentId, string cert, string platform, DateTimeOffset timeFrom, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string>
        {
            ["cert"] = cert,
            ["agentId"] = agentId,
            ["timeFrom"] = timeFrom.ToIso8601String(),
            ["platform"] = platform
        };

        var retryPolicy = Policy
            .HandleResult<JsonDocument?>(r =>
            {
                var status = r?.RootElement.GetProperty("status").GetString();
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

        var document = await retryPolicy.ExecuteAsync(
            async () =>
            await PostAsync(
                apiUrl: apiUrl,
                path: "/fetch/gzip/getTransactionByUpdateDate",
                parameters: parameters,
                logPrefix: "getTransactionByUpdateDate",
                cancellationToken: cancellationToken)
            .ConfigureAwait(false))
            ?? throw new Exception("Document is empty.");

        var status = document.RootElement.GetProperty("status").ToString();

        return
            status != ((int)GameApiClientError.Success).ToString("d4")
            ? new GetTransactionByUpdateDateResult(
                Success: false,
                Transactions: Enumerable.Empty<GetTransactionByUpdateDateTransaction>(),
                Message: document.RootElement.GetProperty("desc").ToString())
            : !document.RootElement.TryGetProperty(("transactions"), out JsonElement transactions)
            ? throw new Exception("JsonElement failed to parse transactions.")
            : new GetTransactionByUpdateDateResult(
            Success: true,
            Transactions: transactions.Deserialize<IEnumerable<GetTransactionByUpdateDateTransaction>>(_SerializerOptions)
            ?? Enumerable.Empty<GetTransactionByUpdateDateTransaction>());
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
            responseMessage = await sr
                .ReadToEndAsync(
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

        return JsonDocument.Parse(responseMessage);
    }
}
