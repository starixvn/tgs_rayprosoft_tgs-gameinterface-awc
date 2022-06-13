using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record OutstandingByBetTimeGetService : IQueryService<OutstandingByBetTimeQuery, OutstandingByBetTimeResult>
    {
        private readonly ILogger<OutstandingByBetTimeGetService> _logger;
        private readonly IGameRecordApiClient _client;

        public OutstandingByBetTimeGetService(
            ILogger<OutstandingByBetTimeGetService> logger,
            IGameRecordApiClient client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async IAsyncEnumerable<OutstandingByBetTimeResult> QueryAsync(OutstandingByBetTimeQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var reslut = await _client.GetOutstandingByBetTimeAsync(
                apiUrl: query.ApiUrl,
                agentId: query.AgentId,
                cert: query.Cert,
                platform: query.Platform,
                startTime: query.StartTime,
                endTime: query.EndTime,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            if (!reslut.Success)
            {
                _logger.LogError("Logon:{logon} | Message:{message}", DateTime.UtcNow.ToString("O"), reslut.Message ?? string.Empty);
                yield break;
            }

            if (reslut.Transactions is null || !reslut.Transactions.Any())
            {
                yield break;
            }

            foreach (var transaction in reslut.Transactions)
            {
                yield return new OutstandingByBetTimeResult(
                    ExternalRoundId: string.Format("{0}-{1}", query.Platform, transaction.PlatformTxId),
                    Platform: query.Platform ?? string.Empty,
                    PlatformTxId: transaction.PlatformTxId ?? string.Empty,
                    GameType: transaction.GameType ?? string.Empty,
                    GameCode: transaction.GameCode ?? string.Empty,
                    GameName: transaction.GameName ?? string.Empty,
                    RoundId: transaction.RoundId ?? string.Empty,
                    UserId: transaction.UserId ?? string.Empty,
                    Currency: transaction.Currency ?? string.Empty,
                    BetTime: transaction.BetTime ?? string.Empty,
                    BetType: transaction.BetType ?? string.Empty,
                    BetAmount: transaction.BetAmount,
                    RealBetAmount: transaction.RealBetAmount,
                    JackpotBetAmount: transaction.JackpotBetAmount,
                    GameInfo: transaction.GameInfo ?? string.Empty);
            }
        }
    }
}
