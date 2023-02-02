using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

internal class AllBalanceQueryService : IQueryService<AllBalanceQuery, AllBalance>
{
    private readonly IGameApiClient _client;

    public AllBalanceQueryService(IGameApiClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public IAsyncEnumerable<AllBalance> QueryAsync(
        AllBalanceQuery query,
        CancellationToken cancellationToken = default)
        => _client
        .GetAllBalancesAsync(
            query.ApiUrl,
            query.AgentId,
            query.Cert,
            cancellationToken);
}
