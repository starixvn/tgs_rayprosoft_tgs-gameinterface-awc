using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.Interfaces;
using Tgs.GameInterface.Awc.ViewModels;

using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Controllers;

[Route("[controller]")]
[ApiController]
public class AwcController : ControllerBase,
    IFundHandler,
    IGamePullRecordHandler,
    IGameSettleHandler,
    IPlayerBalanceHandler,
    IPlayerBalancesHandler,
    IPlayerLogoutHandler
{
    /// <summary>
    /// Alls the balances asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpiawsslot",
    ///             "cert": "ohh3uhFCoeFA66US28G"
    ///         }
    /// </remarks>
    [HttpPost("all/balances")]
    public virtual async IAsyncEnumerable<AllBalanceViewModel> AllBalancesAsync([FromServices] IQueryService<AllBalanceQuery, AllBalanceResult> service, AllBalanceQueryViewModel source)
    {
        var query = new AllBalanceQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert);

        var balances = await service.QueryAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<AllBalanceResult>();

        if (!balances.Any())
        {
            yield break;
        }

        foreach (var balance in balances)
        {
            yield return new AllBalanceViewModel(
                PlayerCode: balance.PlayerCode,
                Balance: balance.Balance,
                LastModified: balance.LastModified);
        }
    }

    /// <summary>
    /// Funds the in asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpicockfight",
    ///             "cert": "qsXFZmTNeLiMrNz1cIJ",
    ///             "playerCode": "4ucmqplxb029",
    ///             "orderId": "8BF8BE2F096D33EBE7A3AF808E26692D",
    ///             "amount": 100
    ///         }
    /// </remarks>
    [HttpPost("fund/in")]
    public virtual async ValueTask<FundResultViewModel> FundInAsync([FromServices] IGetService<FundInQuery, FundResult> service, FundQueryViewModel source)
    {
        var query = new FundInQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            PlayerCode: source.PlayerCode,
            OrderId: source.OrderId,
            Amount: source.Amount);

        var result = await service.GetAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted)
            .ConfigureAwait(false);

        return new FundResultViewModel(
            TransactionId: result.OrderId,
            GameProductTransactionId: result.GameProviderTransactionId,
            Amount: result.Amount,
            CurrentBalance: result.CurrentBalance,
            Resp: result.Resp);
    }

    /// <summary>
    /// Funds the out asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpicockfight",
    ///             "cert": "qsXFZmTNeLiMrNz1cIJ",
    ///             "playerCode": "4ucmqplxb029",
    ///             "orderId": "8BF8BE2F096D33EBE7A3AF808E26692C",
    ///             "amount": 100
    ///         }
    /// </remarks>
    [HttpPost("fund/out")]
    public virtual async ValueTask<FundResultViewModel> FundOutAsync([FromServices] IGetService<FundOutQuery, FundResult> service, FundQueryViewModel source)
    {
        var query = new FundOutQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            PlayerCode: source.PlayerCode,
            OrderId: source.OrderId,
            Amount: source.Amount);

        var result = await service.GetAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted)
            .ConfigureAwait(false);

        return new FundResultViewModel(
            TransactionId: result.OrderId,
            GameProductTransactionId: result.GameProviderTransactionId,
            Amount: result.Amount,
            CurrentBalance: result.CurrentBalance,
            Resp: result.Resp);
    }

    /// <summary>
    /// Funds the status asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Head
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpicockfight",
    ///             "cert": "qsXFZmTNeLiMrNz1cIJ",
    ///             "orderId": "8BF8BE2F096D33EBE7A3AF808E26692D"
    ///         }
    /// </remarks>
    [HttpPost("fund/Status")]
    public virtual ValueTask<bool> FundStatusAsync([FromServices] IGetService<FundStatusQuery, bool> service, FundOrderCheckingViewModel source)
    {
        var query = new FundStatusQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            OrderId: source.OrderId);

        return service.GetAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted);
    }

    /// <summary>
    /// Games the record pull asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    [HttpPost("game/record/pull")]
    public virtual IAsyncEnumerable<GameWagerResultViewModel> GameRecordPullAsync([FromServices] IQueryService<GameWagerSettledQuery, GameWagerResult> service, GamePullRecordQueryViewModel source) => throw new NotImplementedException();

    /// <summary>
    /// Games the record settled asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    [HttpPost("game/record/settled")]
    public virtual IAsyncEnumerable<GameWagerResultViewModel> GameRecordSettledAsync([FromServices] IQueryService<GameWagerQuery, GameWagerResult> service, GameSettleQueryViewModel source) => throw new NotImplementedException();

    /// <summary>
    /// Gets the balance asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpicockfight",
    ///             "cert": "qsXFZmTNeLiMrNz1cIJ",
    ///             "playerCode": "4ucmqplxb029"
    ///         }
    /// </remarks>
    [HttpPost("player/balance")]
    public virtual async ValueTask<BalanceResultViewModel> GetBalanceAsync([FromServices] IGetService<PlayerBalanceQuery, PlayerBalanceResult> service, BalanceQueryViewModel source)
    {
        var query = new PlayerBalanceQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            PlayerCode: source.PlayerCode);

        var result = await service.GetAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted)
            .ConfigureAwait(false);

        return new BalanceResultViewModel(
            result.IsPlayerExist,
            result.Balance);
    }

    /// <summary>
    /// Players the logout asynchronous.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="source"></param>
    /// <returns></returns>
    [HttpPost("player/logout")]
    public virtual ValueTask PlayerLogoutAsync([FromServices] ICommandService<LogoutCommand> service, PlayerLogoutViewModel source)
    {
        var command = new LogoutCommand(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            PlayerCode: source.PlayerCode);

        return service.ExecuteAsync(
            command: command,
            cancellationToken: HttpContext.RequestAborted);
    }
}
