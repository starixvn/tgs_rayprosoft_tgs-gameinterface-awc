using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.ViewModels;

using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Interfaces;

public interface IPlayerCreateByBetLimitHandler
{
    /// <summary>
    /// Players the create by bet limit asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    [HttpPost("player/create/bet-limit")]
    ValueTask PlayerCreateByBetLimitAsync(
        [FromServices] ICommandService<PlayerCreateByBetLimitCommand> service,
        CreatePlayerByBetLimitViewModel source);
}
