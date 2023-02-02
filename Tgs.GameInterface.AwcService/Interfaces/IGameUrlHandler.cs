using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface IGameUrlHandler
{
    [HttpPost("gameurl")]
    ValueTask<GameUrlResultViewModel> GameUrlAsync(
        [FromServices] IGetService<GameUrlQuery, GameUrlResult> service,
        GameUrlQueryViewModel model);
}
