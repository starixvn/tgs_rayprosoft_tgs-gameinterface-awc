using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

internal class GameUrlLobbyByLiveGetService(IGameApiClient client) : IGetService<GameUrlLobbyByLiveQuery, GameUrlResult>
{
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

        var result = await client.LoginAndLaunchGameAsync(
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
