using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface IBalancesHandler
{
    [HttpPost("balances")]
    IAsyncEnumerable<AllBalanceViewModel> GetBalancesAsync(
        [FromServices] IQueryService<AllBalanceQuery, AllBalance> service,
        AllBalanceQueryViewModel model);
}
