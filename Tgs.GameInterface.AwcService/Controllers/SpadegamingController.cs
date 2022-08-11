using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Interfaces;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Controllers;

[Route("AWC_SPADE")]
[ApiController]
public class SpadegamingController : ControllerBase,
    IBalanceHandler,
    IFundHandler,
    IKickPlayerHandler,
    ICreatePlayerHandler,
    IGameUrlHandler,
    IGamePullRecordHandler,
    IGameSettleHandler
{
    /// <summary>
    /// Creates the player asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpispade",
    ///             "cert": "zZDVjvp2QJtg23veYhP",
    ///             "playerCode": "4ucmqplxb029",
    ///             "userName": "4ucmqplxb029",
    ///             "currency": "CNY",
    ///             "language": "cn"
    ///         }
    /// </remarks>
    [HttpPost("create")]
    public ValueTask CreatePlayerAsync(
        [FromServices] ICommandService<CreatePlayerCommand> service,
        CreatePlayerViewModel model)
            => service.ExecuteAsync(new CreatePlayerCommand(
                model.ApiUrl,
                model.AgentId,
                model.Cert,
                model.PlayerCode,
                model.UserName,
                model.Currency,
                model.Language));

    /// <summary>
    /// Funds the in asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpispade",
    ///             "cert": "zZDVjvp2QJtg23veYhP",
    ///             "playerCode": "4ucmqplxb029",
    ///             "transactionId": "8BF8BE2F096D33EBE7A3AF808E26692D",
    ///             "amount": 100
    ///         }
    /// </remarks>
    [HttpPost("fund-in")]
    public async ValueTask<FundResultViewModel> FundInAsync(
        [FromServices] IGetService<FundInQuery, FundInResult> service,
        FundQueryViewModel model)
    {
        var result = await service.GetAsync(new FundInQuery(
            model.ApiUrl,
            model.AgentId,
            model.Cert,
            model.PlayerCode,
            model.TransactionId,
            model.Amount)).ConfigureAwait(false);

        return new FundResultViewModel(
            result.Success,
            result.Message,
            result.TransactionId,
            result.GameProviderTransactionId,
            result.Amount,
            result.CurrentBalance);
    }

    /// <summary>
    /// Funds the order checking asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Head
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpispade",
    ///             "cert": "zZDVjvp2QJtg23veYhP",
    ///             "transactionId": "8BF8BE2F096D33EBE7A3AF808E26692D"
    ///         }
    /// </remarks>
    [HttpPost("fundorderchecking")]
    public ValueTask<bool> FundOrderCheckingAsync(
        [FromServices] IGetService<FundOrderCheckingQuery, bool> service,
        FundOrderCheckingViewModel model)
            => service.GetAsync(new FundOrderCheckingQuery(
                model.ApiUrl,
                model.AgentId,
                model.Cert,
                model.TransactionId));

    /// <summary>
    /// Funds the out asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpispade",
    ///             "cert": "zZDVjvp2QJtg23veYhP",
    ///             "playerCode": "4ucmqplxb029",
    ///             "transactionId": "8BF8BE2F096D33EBE7A3AF808E26692C",
    ///             "amount": 100
    ///         }
    /// </remarks>
    [HttpPost("fund-out")]
    public async ValueTask<FundResultViewModel> FundOutAsync(
        [FromServices] IGetService<FundOutQuery, FundOutResult> service,
        FundQueryViewModel model)
    {
        var result = await service.GetAsync(new FundOutQuery(
            model.ApiUrl,
            model.AgentId,
            model.Cert,
            model.PlayerCode,
            model.TransactionId,
            model.Amount)).ConfigureAwait(false);

        return new FundResultViewModel(
            result.Success,
            result.Message,
            result.TransactionId,
            result.GameProviderTransactionId,
            result.Amount,
            result.CurrentBalance);
    }

    /// <summary>
    /// Games the URL asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpispade",
    ///             "cert": "zZDVjvp2QJtg23veYhP",
    ///             "playerCode": "4ucmqplxb029",
    ///             "isMobileLogin": false,
    ///             "backUrl": "https://dev-t1.rpgp.cc/",
    ///             "externalGameId": SG-FISH-001",
    ///             "language": "cn"
    ///         }
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpispade",
    ///             "cert": "zZDVjvp2QJtg23veYhP",
    ///             "playerCode": "4ucmqplxb029",
    ///             "isMobileLogin": false,
    ///             "backUrl": "https://dev-t1.rpgp.cc/",
    ///             "externalGameId": "SG-SLOT-002",
    ///             "language": "cn"
    ///         }
    /// </remarks>
    [HttpPost("gameurl")]
    public async ValueTask<GameUrlResultViewModel> GameUrlAsync(
        [FromServices] IGetService<GameUrlQuery, GameUrlResult> service,
        GameUrlQueryViewModel model)
    {
        var result = await service.GetAsync(new GameUrlQuery(
            ApiUrl: model.ApiUrl,
            AgentId: model.AgentId,
            Cert: model.Cert,
            PlayerCode: model.PlayerCode,
            IsMobileLogin: model.IsMobileLogin,
            BackUrl: model.BackUrl,
            Platform: AwcPlatforms.AWC_SPADE,
            ExternalGameId: model.ExternalGameId,
            Language: model.Language
            )).ConfigureAwait(false);

        return new GameUrlResultViewModel(
            Success: result.Success,
            Message: result.Message,
            IsPlayerExist: result.IsPlayerExist,
            GameUrl: result.GameUrl);
    }

    /// <summary>
    /// Players the balance asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpispade",
    ///             "cert": "zZDVjvp2QJtg23veYhP",
    ///             "playerCode": "4ucmqplxb029"
    ///         }
    /// </remarks>
    [HttpPost("balance")]
    public async ValueTask<BalanceResultViewModel> GetBalanceAsync(
        [FromServices] IGetService<BalanceQuery, BalanceResult> service,
        BalanceQueryViewModel model)
    {
        var result = await service.GetAsync(new BalanceQuery(
            model.ApiUrl,
            model.AgentId,
            model.Cert,
            model.PlayerCode
            )).ConfigureAwait(false);

        return new BalanceResultViewModel(
            result.Success,
            result.Message,
            result.IsPlayerExist,
            result.Balance);
    }

    /// <summary>
    /// Gets the game pull record asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpispade",
    ///             "cert": "zZDVjvp2QJtg23veYhP",
    ///             "timeFrom": "2022-06-01T08:00:00.000Z"
    ///         }
    ///
    /// </remarks>
    [HttpPost("game/pullrecord")]
    public async IAsyncEnumerable<GamePullRecordResultViewModel> GetGamePullRecordAsync(
        [FromServices] IQueryService<TransactionByUpdateDateQuery, TransactionByUpdateDateResult> service,
        GamePullRecordQueryViewModel model)
    {
        var result = await service.QueryAsync(new TransactionByUpdateDateQuery(
            ApiUrl: model.ApiUrl,
            AgentId: model.AgentId,
            Cert: model.Cert,
            Platform: AwcPlatforms.AWC_SPADE,
            TimeFrom: model.TimeFrom)).ToArrayAsync().ConfigureAwait(false);

        if (!result.Any())
        {
            yield break;
        }

        foreach (var transaction in result)
        {
            yield return new GamePullRecordResultViewModel(
                ExternalRoundId: transaction.ExternalRoundId,
                Platform: transaction.Platform,
                PlatformTxId: transaction.PlatformTxId,
                GameType: transaction.GameType,
                GameCode: transaction.GameCode,
                GameName: transaction.GameName,
                RoundId: transaction.RoundId,
                UserId: transaction.UserId,
                Currency: transaction.Currency,
                TxStatus: transaction.TxStatus,
                SettleStatus: transaction.SettleStatus,
                BetTime: transaction.BetTime,
                TxTime: transaction.TxTime,
                UpdateTime: transaction.UpdateTime,
                BetType: transaction.BetType,
                BetAmount: transaction.BetAmount,
                RealBetAmount: transaction.RealBetAmount,
                Turnover: transaction.Turnover,
                WinAmount: transaction.WinAmount,
                RealWinAmount: transaction.RealWinAmount,
                JackpotBetAmount: transaction.JackpotBetAmount,
                JackpotWinAmount: transaction.JackpotWinAmount,
                GameInfo: transaction.GameInfo);
        }
    }

    /// <summary>
    /// Gets the game settle asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpispade",
    ///             "cert": "zZDVjvp2QJtg23veYhP",
    ///             "startTime": "2022-06-10T05:30:00.000Z",
    ///             "endTime": "2022-06-10T06:30:00.000Z"
    ///         }
    ///
    /// </remarks>
    [HttpPost("game/settle")]
    public async IAsyncEnumerable<GameSettleTransactionViewModel> GetGameSettleAsync(
        [FromServices] IQueryService<TransactionByTxTimeQuery, TransactionByTxTimeResult> service,
        GameSettleQueryViewModel model)
    {
        var result = await service.QueryAsync(new TransactionByTxTimeQuery(
            ApiUrl: model.ApiUrl,
            AgentId: model.AgentId,
            Cert: model.Cert,
            Platform: AwcPlatforms.AWC_SPADE,
            StartTime: model.StartTime,
            EndTime: model.EndTime
            )).ToArrayAsync().ConfigureAwait(false);

        if (!result.Any())
        {
            yield break;
        }

        foreach (var transaction in result)
        {
            yield return new GameSettleTransactionViewModel(
                ExternalRoundId: transaction.ExternalRoundId,
                Platform: transaction.Platform,
                PlatformTxId: transaction.PlatformTxId,
                GameType: transaction.GameType,
                GameCode: transaction.GameCode,
                GameName: transaction.GameName,
                RoundId: transaction.RoundId,
                UserId: transaction.UserId,
                Currency: transaction.Currency,
                TxStatus: transaction.TxStatus,
                SettleStatus: transaction.SettleStatus,
                BetTime: transaction.BetTime,
                TxTime: transaction.TxTime,
                UpdateTime: transaction.UpdateTime,
                BetType: transaction.BetType,
                BetAmount: transaction.BetAmount,
                RealBetAmount: transaction.RealBetAmount,
                Turnover: transaction.Turnover,
                WinAmount: transaction.WinAmount,
                RealWinAmount: transaction.RealWinAmount,
                JackpotBetAmount: transaction.JackpotBetAmount,
                JackpotWinAmount: transaction.JackpotWinAmount,
                GameInfo: transaction.GameInfo);
        }
    }

    /// <summary>
    /// Kicks the player asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpispade",
    ///             "cert": "zZDVjvp2QJtg23veYhP",
    ///             "playerCode": "4ucmqplxb029"
    ///         }
    /// </remarks>
    [HttpPost("kick")]
    public ValueTask KickPlayerAsync(
        [FromServices] ICommandService<LogoutCommand> service,
        KickPlayerViewModel model)
    => service.ExecuteAsync(new LogoutCommand(
        model.ApiUrl,
        model.AgentId,
        model.Cert,
        model.PlayerCode));
}
