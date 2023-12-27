using System.Runtime.CompilerServices;
using Tgs.GameInterface.Awc.Core.Models;

using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

internal class GameWagerSettledQueryService(
    IGameRecordApiClient client,
    IGameWagerUtensil utensil) : IQueryService<GameWagerSettledQuery, GameWagerResult>
{
    public async IAsyncEnumerable<GameWagerResult> QueryAsync(GameWagerSettledQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var transactions = await client.GetTransactionByUpdateDateAsync(
            apiUrl: query.ApiUrl,
            agentId: query.AgentId,
            cert: query.Cert,
            platform: query.Platform,
            timeFrom: query.TimeFrom,
            cancellationToken: cancellationToken)
            .ToArrayAsync(
            cancellationToken: cancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GetTransactionByUpdateDateTransaction>();

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
            var isClosed = utensil.IsClosed(transaction.TxStatus);
            var isCanceled = utensil.IsCanceled(transaction.TxStatus);
            var isVoid = utensil.IsVoid(transaction.TxStatus, transaction.SettleStatus);
            var isCashout = utensil.IsCashout(transaction.TxStatus);
            var externalCreatedOn = DateTimeOffset.Parse(transaction.BetTime!);
            var externalClosedOn = DateTimeOffset.UnixEpoch;
            var betAmount = transaction.BetAmount;
            var validBetAmount = transaction.RealBetAmount;
            var settle = 0.0m;
            var turnover = 0.0m;
            var winLoss = 0.0m;
            if (isClosed || isVoid)
            {
                externalClosedOn = DateTimeOffset.Parse(transaction.TxTime!);
                settle = transaction.RealWinAmount;
                turnover = transaction.Turnover;
                winLoss = settle - validBetAmount;
                if (isCanceled || isVoid)
                {
                    winLoss = 0.0m;
                }
            }

            yield return new GameWagerResult(
                ExternalRoundId: transaction.RoundId,
                ExternalWagerId: string.Format("{0}-{1}", query.Platform, transaction.PlatformTxId),
                ExternalGameId: transaction.GameCode,
                PlayerCode: transaction.UserId,
                IsClosed: isClosed,
                IsCanceled: isCanceled,
                IsVoid: isVoid,
                IsCashout: isCashout,
                ExternalCreatedOn: externalCreatedOn,
                ExternalClosedOn: externalClosedOn,
                Bet: betAmount,
                ValidBet: validBetAmount,
                Settle: settle,
                Turnover: turnover,
                WinLoss: winLoss,
                AdditionalData: transaction.AdditionalData);
        }
    }
}
