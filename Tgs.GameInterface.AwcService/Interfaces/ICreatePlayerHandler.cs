using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface ICreatePlayerHandler
{
    [HttpPost("create")]
    ValueTask CreatePlayerAsync(
        [FromServices] ICommandService<CreatePlayerCommand> service,
        CreatePlayerViewModel model);
}
