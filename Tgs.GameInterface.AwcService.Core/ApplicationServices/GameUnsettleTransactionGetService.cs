using System.Runtime.CompilerServices;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record GameUnsettleTransactionGetService : IQueryService<GameUnsettleTransactionQuery, GameUnsettleTransactionResult>
    {
        private readonly IGameRecordApiClient _client;

        public GameUnsettleTransactionGetService(IGameRecordApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async IAsyncEnumerable<GameUnsettleTransactionResult> QueryAsync(GameUnsettleTransactionQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
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
                yield break;
            }

            if (reslut.Transactions is null || !reslut.Transactions.Any())
            {
                yield break;
            }

            foreach (var transaction in reslut.Transactions)
            {
                yield return new GameUnsettleTransactionResult(
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
