using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface IGamePullRecordHandler
{
    [HttpPost("game/pullrecord")]
    IAsyncEnumerable<GamePullRecordResultViewModel> GetGamePullRecordAsync([FromServices] IQueryService<TransactionByUpdateDateQuery, TransactionByUpdateDateResult> service, GamePullRecordQueryViewModel model);
}
