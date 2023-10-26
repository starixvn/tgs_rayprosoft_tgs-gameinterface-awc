using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

internal class GameUrlLobbyByLiveGetService : IGetService<GameUrlLobbyByLiveQuery, GameUrlResult>
{
    private readonly IGameApiClient _client;

    public GameUrlLobbyByLiveGetService(IGameApiClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<GameUrlResult> GetAsync(GameUrlLobbyByLiveQuery query, CancellationToken cancellationToken = default)
    {
        var data = new LoginAndLaunchGameByLive(
            PlayerCode: query.PlayerCode,
            IsMobileLogin: query.IsMobileLogin,
            BackUrl: query.BackUrl,
            Platform: query.Platform,
            ExternalGameId: query.ExternalGameId,
            BetLimit: query.BetLimit,
            Language: query.Language);

        var result = await _client.LoginAndLaunchGameAsync(
            query.ApiUrl,
            query.AgentId,
            query.Cert,
            data,
            cancellationToken).ConfigureAwait(false);

        return new GameUrlResult(
            IsPlayerExist: result.IsPlayerExist,
            GameUrl: result.GameUrl);
    }
}
