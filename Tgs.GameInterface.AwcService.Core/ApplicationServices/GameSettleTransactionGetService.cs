using System.Runtime.CompilerServices;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    internal class GameSettleTransactionGetService : IQueryService<GameSettleTransactionQuery, GameSettleTransactionResult>
    {
        private readonly IGameApiClient _client;

        public GameSettleTransactionGetService(IGameApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async IAsyncEnumerable<GameSettleTransactionResult> QueryAsync(GameSettleTransactionQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var reslut = await _client.GetTransactionByTxTimeAsync(
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
                yield return new GameSettleTransactionResult(
                    ExternalRoundId: string.Format("{0}-{1}", query.Platform, transaction.PlatformTxId),
                    Platform: query.Platform,
                    PlatformTxId: transaction.PlatformTxId,
                    GameType: transaction.GameType,
                    GameCode: transaction.GameCode,
                    GameName: transaction.GameName,
                    RoundId: transaction.RoundId,
                    UserId: transaction.UserId,
                    Currency: transaction.Currency,
                    TxStatus: transaction.TxStatus,
                    SettleStatus: transaction.SettleStatus,
                    BetTime: transaction.BetTime,
                    TxTime: transaction.TxTime,
                    UpdateTime: transaction.UpdateTime,
                    BetType: transaction.BetType,
                    BetAmount: transaction.BetAmount,
                    RealBetAmount: transaction.RealBetAmount,
                    Turnover: transaction.Turnover,
                    WinAmount: transaction.WinAmount,
                    RealWinAmount: transaction.RealWinAmount,
                    JackpotBetAmount: transaction.JackpotBetAmount,
                    JackpotWinAmount: transaction.JackpotWinAmount,
                    GameInfo: transaction.GameInfo);
            }
        }
    }
}
