using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.ViewModels;

using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Interfaces;

public interface IPlayerBalancesHandler
{
    [HttpPost("all/balances")]
    IAsyncEnumerable<AllBalanceViewModel> AllBalancesAsync(
        [FromServices] IQueryService<AllBalanceQuery, AllBalanceResult> service,
        AllBalanceQueryViewModel source);
}
