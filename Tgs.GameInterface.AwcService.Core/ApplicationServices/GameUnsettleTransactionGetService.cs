using System.Runtime.CompilerServices;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record GameUnsettleTransactionGetService : IQueryService<GameUnsettleTransactionQuery, GameUnsettleTransactionResult>
    {
        private readonly IGameApiClient _client;

        public GameUnsettleTransactionGetService(IGameApiClient client)
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
                    Platform: query.Platform,
                    PlatformTxId: transaction.PlatformTxId,
                    GameType: transaction.GameType,
                    GameCode: transaction.GameCode,
                    GameName: transaction.GameName,
                    RoundId: transaction.RoundId,
                    UserId: transaction.UserId,
                    Currency: transaction.Currency,
                    BetTime: transaction.BetTime,
                    BetType: transaction.BetType,
                    BetAmount: transaction.BetAmount,
                    RealBetAmount: transaction.RealBetAmount,
                    JackpotBetAmount: transaction.JackpotBetAmount,
                    GameInfo: transaction.GameInfo);
            }
        }
    }
}
