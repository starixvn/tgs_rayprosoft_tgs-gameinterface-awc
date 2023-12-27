using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.ViewModels;

using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Interfaces;

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
