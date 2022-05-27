using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    internal class GameUrlByLottoGetService : IGetService<GameUrlByLottoQuery, GameUrlResult>
    {
        private readonly IGameApiClient _client;

        public GameUrlByLottoGetService(IGameApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async ValueTask<GameUrlResult> GetAsync(GameUrlByLottoQuery query, CancellationToken cancellationToken = default)
        {
            var data = new LoginAndLaunchGameByLottoData()
            {
                PlayerCode = query.PlayerCode,
                IsMobileLogin = query.IsMobileLogin,
                ExternalURL = query.ExternalURL,
                Platform = query.Platform,
                Language = query.Language
            };

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
