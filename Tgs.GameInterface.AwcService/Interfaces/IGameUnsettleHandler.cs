using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces
{
    public interface IGameUnsettleHandler
    {
        [HttpPost("game/unsettle")]
        IAsyncEnumerable<GameUnsettleTransactionViewModel> GameUnsettleAsync([FromServices] IQueryService<GameUnsettleTransactionQuery, GameUnsettleTransactionResult> service, GameUnsettleQueryViewModel model);
    }
}
