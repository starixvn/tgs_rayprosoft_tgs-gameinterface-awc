using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

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
