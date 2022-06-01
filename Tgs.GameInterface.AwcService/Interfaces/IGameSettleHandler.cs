using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces
{
    public interface IGameSettleHandler
    {
        [HttpPost("game/settle")]
        IAsyncEnumerable<GameSettleTransactionViewModel> GameSettleAsync([FromServices] IQueryService<GameSettleTransactionQuery, GameSettleTransactionResult> service, GameSettleQueryViewModel model);
    }
}
