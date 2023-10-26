using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface IPlayerLogoutHandler
{
    /// <summary>
    /// Players the logout asynchronous.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="source"></param>
    /// <returns></returns>
    [HttpPost("player/logout", Name = "PlayerLogout")]
    ValueTask PlayerLogoutAsync(
        [FromServices] ICommandService<LogoutCommand> service,
        PlayerLogoutViewModel source);
}
