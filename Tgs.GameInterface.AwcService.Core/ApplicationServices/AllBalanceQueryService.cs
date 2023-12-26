using System.Runtime.CompilerServices;
using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

internal class AllBalanceQueryService(IGameApiClient client) : IQueryService<AllBalanceQuery, AllBalanceResult>
{
    public async IAsyncEnumerable<AllBalanceResult> QueryAsync(
        AllBalanceQuery query,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var balances = await client.GetAllBalancesAsync(
            apiUrl: query.ApiUrl,
            agentId: query.AgentId,
            cert: query.Cert,
            cancellationToken: cancellationToken)
            .ToArrayAsync(
            cancellationToken: cancellationToken)
            ?? Enumerable.Empty<BalanceInfo>();

        if (!balances.Any())
        {
            yield break;
        }

        foreach (var balance in balances)
        {
            yield return new AllBalanceResult(
                balance.UserId,
                balance.Balance,
                balance.LastModified);
        }
    }
}
