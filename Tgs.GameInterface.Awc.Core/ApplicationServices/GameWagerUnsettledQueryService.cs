using System.Runtime.CompilerServices;
using Tgs.GameInterface.Awc.Core.Models;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

internal class GameWagerUnsettledQueryService(
    IGameRecordApiClient client) : IQueryService<GameWagerUnsettledQuery, GameWagerResult>
{
    public async IAsyncEnumerable<GameWagerResult> QueryAsync(GameWagerUnsettledQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var transactions = await client.GetOutstandingByBetTimeAsync(
            apiUrl: query.ApiUrl,
            agentId: query.AgentId,
            cert: query.Cert,
            platform: query.Platform,
            startTime: query.StartTime,
            endTime: query.EndTime,
            cancellationToken: cancellationToken)
            .ToArrayAsync(
            cancellationToken: cancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GetOutstandingByBetTimeTransaction>();

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

            yield return new GameWagerResult(
                ExternalRoundId: transaction.RoundId,
                ExternalWagerId: string.Format("{0}-{1}", query.Platform, transaction.PlatformTxId),
                ExternalGameId: transaction.GameCode,
                PlayerCode: transaction.UserId,
                IsClosed: false,
                IsCanceled: false,
                IsVoid: false,
                IsCashout: false,
                ExternalCreatedOn: DateTimeOffset.Parse(transaction.BetTime),
                ExternalClosedOn: DateTimeOffset.UnixEpoch,
                Bet: transaction.BetAmount,
                ValidBet: transaction.RealBetAmount,
                Settle: 0.0m,
                Turnover: 0.0m,
                WinLoss: 0.0m,
                AdditionalData: transaction.AdditionalData);
        }
    }
}
