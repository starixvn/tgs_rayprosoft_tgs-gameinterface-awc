using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Interfaces;

public interface IFundHandler
{
    /// <summary>
    /// Funds the in asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    [HttpPost("fund/in")]
    ValueTask<FundResultViewModel> FundInAsync(
        [FromServices] IGetService<FundInQuery, FundResult> service,
        FundQueryViewModel source);

    /// <summary>
    /// Funds the out asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    [HttpPost("fund/out")]
    ValueTask<FundResultViewModel> FundOutAsync(
        [FromServices] IGetService<FundOutQuery, FundResult> service,
        FundQueryViewModel source);

    /// <summary>
    /// Funds the status asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    [HttpPost("fund/Status")]
    ValueTask<bool> FundStatusAsync(
        [FromServices] IGetService<FundStatusQuery, bool> service,
        FundOrderCheckingViewModel source);
}
