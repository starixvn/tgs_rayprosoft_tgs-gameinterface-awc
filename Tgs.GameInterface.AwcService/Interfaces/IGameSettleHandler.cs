using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface IGameSettleHandler
{
    /// <summary>
    /// Games the record settled asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    [HttpPost("game/record/settled")]
    IAsyncEnumerable<GameTransactionViewModel> GameRecordSettledAsync(
        [FromServices] IQueryService<GameRecordQuery, GameRecordResult> service,
        GameSettleQueryViewModel source);
}
