using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.ViewModels;

using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Interfaces;

public interface IGameSettleHandler
{
    /// <summary>
    /// Games the record settled asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    [HttpPost("game/record/settled")]
    IAsyncEnumerable<GameWagerResultViewModel> GameRecordSettledAsync(
        [FromServices] IQueryService<GameWagerQuery, GameWagerResult> service,
        GameSettleQueryViewModel source);
}
