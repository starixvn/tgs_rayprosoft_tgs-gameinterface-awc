using Tgs.GameInterface.AwcService.Common;
using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    internal class GameUrlGetService : IGetService<GameUrlQuery, GameUrlResult>
    {
        private readonly IGameApiClient _client;

        public GameUrlGetService(IGameApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async ValueTask<GameUrlResult> GetAsync(GameUrlQuery query, CancellationToken cancellationToken = default)
        {
            var gameCodeSplits = query.ExternalGameId.Split("-");
            var gameType = gameCodeSplits[1].ToUpper() switch
            {
                "SLOT" => AwcGameTypes.SLOT.ToString(),
                "FISH" => AwcGameTypes.FH.ToString(),
                "FH" => AwcGameTypes.FH.ToString(),
                "EGAME" => AwcGameTypes.EGAME.ToString(),
                "TABLE" => AwcGameTypes.TABLE.ToString(),
                "LOTTO" => AwcGameTypes.LOTTO.ToString(),
                _ => throw new NotImplementedException(),
            };

            var data = new LoginAndLaunchGame(
                PlayerCode: query.PlayerCode,
                IsMobileLogin: query.IsMobileLogin,
                ExternalURL: query.ExternalURL,
                Platform: query.Platform,
                GameType: gameType,
                ExternalGameId: query.ExternalGameId,
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
