using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Common;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Interfaces;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Controllers
{
    [Route("VENUS")]
    [ApiController]
    public class VenusGamingController : ControllerBase,
        IBalanceHandler,
        IFundHandler,
        IKickPlayerHandler,
        ICreatePlayerByBetLimitHandler,
        ILobbyGameUrlByLiveHandler
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
        ///             "agentId": "cnygpivenus",
        ///             "cert": "DfyfVhwJ8akfz2aGo3K",
        ///             "playerCode": "4ucmqplxb029",
        ///             "userName": "4ucmqplxb029",
        ///             "currency": "CNY",
        ///             "betLimit": "{\"VENUS\":{\"LIVE\":{\"limitId\":[280303,280304,280305]}}}",
        ///             "language": "cn"
        ///         }
        /// </remarks>
        [HttpPost("create")]
        public ValueTask CreatePlayerAsync(
                    [FromServices] ICommandService<CreatePlayerByBetLimitCommand> service,
                    CreatePlayerByBetLimitViewModel model)
                    => service.ExecuteAsync(new CreatePlayerByBetLimitCommand(
                        model.ApiUrl,
                        model.AgentId,
                        model.Cert,
                        model.PlayerCode,
                        model.UserName,
                        model.Currency,
                        model.BetLimit,
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
        ///             "agentId": "cnygpivenus",
        ///             "cert": "DfyfVhwJ8akfz2aGo3K",
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
                result.TransactionId,
                result.GameProductTransactionId,
                result.Amount,
                result.CurrentBalance);
        }

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
        ///             "agentId": "cnygpivenus",
        ///             "cert": "DfyfVhwJ8akfz2aGo3K",
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
                result.TransactionId,
                result.GameProductTransactionId,
                result.Amount,
                result.CurrentBalance);
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
        ///             "agentId": "cnygpivenus",
        ///             "cert": "DfyfVhwJ8akfz2aGo3K",
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
                result.IsPlayerExist,
                result.Balance);
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
        ///             "agentId": "cnygpivenus",
        ///             "cert": "DfyfVhwJ8akfz2aGo3K",
        ///             "playerCode": "4ucmqplxb029"
        ///         }
        /// </remarks>
        [HttpPost("kick")]
        public ValueTask KickPlayerAsync([FromServices] ICommandService<LogoutCommand> service, KickPlayerViewModel model)
        => service.ExecuteAsync(new LogoutCommand(
            model.ApiUrl,
            model.AgentId,
            model.Cert,
            model.PlayerCode));

        /// <summary>
        /// Lobbies the game URL by live asynchronous.
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
        ///             "agentId": "cnygpivenus",
        ///             "cert": "DfyfVhwJ8akfz2aGo3K",
        ///             "playerCode": "4ucmqplxb029",
        ///             "isMobileLogin": false,
        ///             "backUrl": "https://dev-t1.rpgp.cc/",
        ///             "betLimit": "{\"VENUS\":{\"LIVE\":{\"limitId\":[280303,280304,280305]}}}",
        ///             "language": "cn"
        ///         }
        ///
        /// </remarks>
        [HttpPost("lobby/live")]
        public async ValueTask<GameUrlResultViewModel> LobbyGameUrlByLiveAsync(
            [FromServices] IGetService<GameUrlByLiveLobbyQuery, GameUrlResult> service,
            GameUrlByLiveLobbyQueryViewModel model)

        {
            var result = await service.GetAsync(new GameUrlByLiveLobbyQuery(
                ApiUrl: model.ApiUrl,
                AgentId: model.AgentId,
                Cert: model.Cert,
                PlayerCode: model.PlayerCode,
                IsMobileLogin: model.IsMobileLogin,
                BackUrl: model.BackUrl,
                Platform: AwcPlatforms.AWC_VENUS,
                BetLimit: model.BetLimit,
                Language: model.Language)).ConfigureAwait(false);

            return new GameUrlResultViewModel(
                Success: result.Success,
                Message: result.Message,
                IsPlayerExist: result.IsPlayerExist,
                GameUrl: result.GameUrl);
        }
    }
}
