using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces
{
    public interface ILobbyGameUrlByLiveHandler
    {
        /// <summary>
        /// Lobbies the game URL by live asynchronous.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("lobby/live")]
        ValueTask<GameUrlResultViewModel> LobbyGameUrlByLiveAsync([FromServices] IGetService<GameUrlByLiveQuery, GameUrlResult> service, GameUrlByLiveQueryViewModel model);
    }
}
