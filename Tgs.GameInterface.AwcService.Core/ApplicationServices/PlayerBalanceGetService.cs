using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

internal class PlayerBalanceGetService(IGameApiClient client) : IGetService<PlayerBalanceQuery, PlayerBalanceResult>
{
    public async ValueTask<PlayerBalanceResult> GetAsync(PlayerBalanceQuery query, CancellationToken cancellationToken = default)
    {
        var result = await client.GetBalanceAsync(
            query.ApiUrl,
            query.AgentId,
            query.Cert,
            query.PlayerCode,
            cancellationToken).ConfigureAwait(false);

        return new PlayerBalanceResult(
            IsPlayerExist: result.IsPlayerExist,
            Balance: result.Balance);
    }
}
