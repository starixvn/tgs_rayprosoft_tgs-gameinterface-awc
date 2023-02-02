using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface IKickPlayerHandler
{
    [HttpPost("kick")]
    ValueTask KickPlayerAsync(
        [FromServices] ICommandService<LogoutCommand> service,
        KickPlayerViewModel model);
}
