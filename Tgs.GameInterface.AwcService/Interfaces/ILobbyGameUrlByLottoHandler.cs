using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces
{
    public interface ILobbyGameUrlByLottoHandler
    {
        /// <summary>
        /// Lobbies the game URL by lotto asynchronous.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("lobby/lotto")]
        ValueTask<GameUrlResultViewModel> LobbyGameUrlByLottoAsync([FromServices] IGetService<GameUrlByLottoLobbyQuery, GameUrlResult> service, GameUrlByLottoLobbyQueryViewModel model);
    }
}
