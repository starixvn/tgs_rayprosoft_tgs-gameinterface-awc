using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces
{
    public interface IFundHandler
    {
        [HttpPost("fundin")]
        ValueTask<FundResultViewModel> FundInAsync([FromServices] IGetService<FundInQuery, FundInResult> service, FundQueryViewModel model);

        [HttpPost("fundout")]
        ValueTask<FundResultViewModel> FundOutAsync([FromServices] IGetService<FundOutQuery, FundOutResult> service, FundQueryViewModel model);
    }
}
