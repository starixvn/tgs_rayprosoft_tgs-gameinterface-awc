using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface IPlayerBalanceHandler
{
    [HttpPost("player/balance")]
    ValueTask<BalanceResultViewModel> GetBalanceAsync(
        [FromServices] IGetService<PlayerBalanceQuery, PlayerBalanceResult> service,
        BalanceQueryViewModel source);
}
