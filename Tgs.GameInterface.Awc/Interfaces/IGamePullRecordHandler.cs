using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.ViewModels;

using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Interfaces;

public interface IGamePullRecordHandler
{
    /// <summary>
    /// Games the record pull asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    [HttpPost("game/record/pull")]
    IAsyncEnumerable<GameWagerResultViewModel> GameRecordPullAsync(
        [FromServices] IQueryService<GameWagerSettledQuery, GameWagerResult> service,
        GamePullRecordQueryViewModel source);
}
