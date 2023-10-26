using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface IPlayerBalancesHandler
{
    [HttpPost("all/balances")]
    IAsyncEnumerable<AllBalanceViewModel> AllBalancesAsync(
        [FromServices] IQueryService<AllBalanceQuery, AllBalanceResult> service,
        AllBalanceQueryViewModel source);
}
