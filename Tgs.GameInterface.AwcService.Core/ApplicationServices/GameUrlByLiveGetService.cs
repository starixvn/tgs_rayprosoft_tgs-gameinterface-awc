using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    internal class GameUrlByLiveGetService : IGetService<GameUrlByLiveQuery, GameUrlResult>
    {
        private readonly IGameApiClient _client;

        public GameUrlByLiveGetService(IGameApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async ValueTask<GameUrlResult> GetAsync(GameUrlByLiveQuery query, CancellationToken cancellationToken = default)
        {
            var data = new LoginAndLaunchGameByLive(
                PlayerCode: query.PlayerCode,
                IsMobileLogin: query.IsMobileLogin,
                ExternalURL: query.ExternalURL,
                Platform: query.Platform,
                ExternalGameId: query.ExternalGameId,
                BetLimit: query.BetLimit,
                Language: query.Language);

            var reslut = await _client.LoginAndLaunchGameAsync(
                query.ApiUrl,
                query.AgentId,
                query.Cert,
                data,
                cancellationToken).ConfigureAwait(false);

            return new GameUrlResult(
                Success: reslut.Success,
                Message: reslut.Message,
                IsPlayerExist: reslut.IsPlayerExist,
                GameUrl: reslut.GameUrl);
        }
    }
}
