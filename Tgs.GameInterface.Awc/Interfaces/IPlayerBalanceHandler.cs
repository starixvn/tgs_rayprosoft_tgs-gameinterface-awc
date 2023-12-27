using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.ViewModels;

using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Interfaces;

public interface IPlayerBalanceHandler
{
    [HttpPost("player/balance")]
    ValueTask<BalanceResultViewModel> GetBalanceAsync(
        [FromServices] IGetService<PlayerBalanceQuery, PlayerBalanceResult> service,
        BalanceQueryViewModel source);
}
