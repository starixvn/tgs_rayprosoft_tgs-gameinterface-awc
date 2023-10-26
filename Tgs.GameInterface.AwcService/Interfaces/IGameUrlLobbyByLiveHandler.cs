using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface IGameUrlLobbyByLiveHandler
{
    /// <summary>
    /// Games the URL lobby by live asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    [HttpPost("game/url/lobby/live")]
    ValueTask<GameUrlResultViewModel> GameUrlLobbyByLiveAsync(
        [FromServices] IGetService<GameUrlLobbyByLiveQuery, GameUrlResult> service,
        GameUrlByLiveLobbyQueryViewModel source);
}
