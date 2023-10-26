using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

internal class PlayerBalanceGetService : IGetService<PlayerBalanceQuery, PlayerBalanceResult>
{
    private readonly IGameApiClient _client;

    public PlayerBalanceGetService(IGameApiClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<PlayerBalanceResult> GetAsync(PlayerBalanceQuery query, CancellationToken cancellationToken = default)
    {
        var result = await _client.GetBalanceAsync(
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
