using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    internal class GameUrlByLottoLobbyGetService : IGetService<GameUrlByLottoLobbyQuery, GameUrlResult>
    {
        private readonly IGameApiClient _client;

        public GameUrlByLottoLobbyGetService(IGameApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async ValueTask<GameUrlResult> GetAsync(GameUrlByLottoLobbyQuery query, CancellationToken cancellationToken = default)
        {
            var data = new LoginAndLaunchGameByLottoLobby(
                PlayerCode: query.PlayerCode,
                IsMobileLogin: query.IsMobileLogin,
                ExternalURL: query.ExternalURL,
                Platform: query.Platform,
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
