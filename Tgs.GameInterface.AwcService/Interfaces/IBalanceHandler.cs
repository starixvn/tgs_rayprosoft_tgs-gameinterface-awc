using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface IBalanceHandler
{
    [HttpPost("balance")]
    ValueTask<BalanceResultViewModel> GetBalanceAsync(
        [FromServices] IGetService<BalanceQuery, BalanceResult> service,
        BalanceQueryViewModel model);
}
