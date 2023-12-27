using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.Awc.Core;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.Interfaces;
using Tgs.GameInterface.Awc.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Controllers;

[Route("AWC_BG")]
[ApiController]
public class BigGamingController : AwcController,
    IGameUrlLobbyByLiveHandler,
    IPlayerCreateByBetLimitHandler
{
    /// <summary>
    /// Games the record pull asynchronous.
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
    ///             "agentId": "gpicnybg",
    ///             "cert": "alTtVQ7lXScPjQuCmvd",
    ///             "timeFrom": "2022-06-01T08:00:00.000Z"
    ///         }
    ///
    /// </remarks>
    public override async IAsyncEnumerable<GameWagerResultViewModel> GameRecordPullAsync(
        [FromServices] IQueryService<GameWagerSettledQuery, GameWagerResult> service,
        GamePullRecordQueryViewModel source)
    {
        var query = new GameWagerSettledQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            Platform: AwcPlatforms.AWC_BG,
            TimeFrom: source.TimeFrom);

        var results = await service.QueryAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        if (!results.Any())
        {
            yield break;
        }

        foreach (var result in results)
        {
            yield return new GameWagerResultViewModel(
                ExternalRoundId: result.ExternalRoundId,
                ExternalWagerId: result.ExternalWagerId,
                ExternalGameId: result.ExternalGameId,
                PlayerCode: result.PlayerCode,
                IsClosed: result.IsClosed,
                IsCanceled: result.IsCanceled,
                IsVoid: result.IsVoid,
                IsCashout: result.IsCashout,
                ExternalCreatedOn: result.ExternalCreatedOn,
                ExternalClosedOn: result.ExternalClosedOn,
                Bet: result.Bet,
                ValidBet: result.ValidBet,
                Settle: result.Settle,
                Turnover: result.Turnover,
                WinLoss: result.WinLoss,
                AdditionalData: result.AdditionalData);
        }
    }

    /// <summary>
    /// Games the record settled asynchronous.
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
    ///             "agentId": "gpicnybg",
    ///             "cert": "alTtVQ7lXScPjQuCmvd",
    ///             "startTime": "2022-06-10T05:30:00.000Z",
    ///             "endTime": "2022-06-10T06:30:00.000Z"
    ///         }
    ///
    /// </remarks>
    public override async IAsyncEnumerable<GameWagerResultViewModel> GameRecordSettledAsync(
        [FromServices] IQueryService<GameWagerQuery, GameWagerResult> service,
        GameSettleQueryViewModel source)
    {
        var query = new GameWagerQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            Platform: AwcPlatforms.AWC_BG,
            StartTime: source.StartTime,
            EndTime: source.EndTime);

        var results = await service.QueryAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameWagerResult>();

        if (!results.Any())
        {
            yield break;
        }

        foreach (var result in results)
        {
            yield return new GameWagerResultViewModel(
                ExternalRoundId: result.ExternalRoundId,
                ExternalWagerId: result.ExternalWagerId,
                ExternalGameId: result.ExternalGameId,
                PlayerCode: result.PlayerCode,
                IsClosed: result.IsClosed,
                IsCanceled: result.IsCanceled,
                IsVoid: result.IsVoid,
                IsCashout: result.IsCashout,
                ExternalCreatedOn: result.ExternalCreatedOn,
                ExternalClosedOn: result.ExternalClosedOn,
                Bet: result.Bet,
                ValidBet: result.ValidBet,
                Settle: result.Settle,
                Turnover: result.Turnover,
                WinLoss: result.WinLoss,
                AdditionalData: result.AdditionalData);
        }
    }

    /// <summary>
    /// Lobbies the game URL by live asynchronous.
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
    ///             "agentId": "gpicnybg",
    ///             "cert": "alTtVQ7lXScPjQuCmvd",
    ///             "playerCode": "4ucmqplxb029",
    ///             "isMobileLogin": false,
    ///             "backUrl": "https://dev-t1.rpgp.cc/",
    ///             "betLimit": "{\"BG\":{\"LIVE\":{\"limitId\":[\"A\",\"B\"]}}}",
    ///             "language": "cn"
    ///         }
    ///
    /// </remarks>
    [HttpPost("game/url/lobby/live")]
    public async ValueTask<GameUrlResultViewModel> GameUrlLobbyByLiveAsync(
        [FromServices] IGetService<GameUrlLobbyByLiveQuery, GameUrlResult> service,
        GameUrlByLiveLobbyQueryViewModel source)
    {
        var query = new GameUrlLobbyByLiveQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            PlayerCode: source.PlayerCode,
            IsMobileLogin: source.IsMobileLogin,
            BackUrl: source.BackUrl,
            Platform: AwcPlatforms.AWC_BG,
            ExternalGameId: "BG-LIVE-001",
            BetLimit: source.BetLimit,
            Language: source.Language);

        var result = await service.GetAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted)
            .ConfigureAwait(false);

        return new GameUrlResultViewModel(
            IsPlayerExist: result.IsPlayerExist,
            GameUrl: result.GameUrl);
    }

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
    ///             "agentId": "gpicnybg",
    ///             "cert": "alTtVQ7lXScPjQuCmvd",
    ///             "playerCode": "4ucmqplxb029"
    ///         }
    /// </remarks>
    public override ValueTask<BalanceResultViewModel> GetBalanceAsync(
        [FromServices] IGetService<PlayerBalanceQuery, PlayerBalanceResult> service,
        BalanceQueryViewModel source)
        => base.GetBalanceAsync(service, source);

    /// <summary>
    /// Players the create asynchronous.
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
    ///             "agentId": "gpicnybg",
    ///             "cert": "alTtVQ7lXScPjQuCmvd",
    ///             "playerCode": "4ucmqplxb029",
    ///             "userName": "4ucmqplxb029",
    ///             "currency": "CNY",
    ///             "betLimit": "{\"BG\":{\"LIVE\":{\"limitId\":[\"A\",\"B\"]}}}",
    ///             "language": "cn"
    ///         }
    /// </remarks>
    [HttpPost("player/create")]
    public ValueTask PlayerCreateByBetLimitAsync(
        [FromServices] ICommandService<PlayerCreateByBetLimitCommand> service,
        CreatePlayerByBetLimitViewModel source)
    {
        var command = new PlayerCreateByBetLimitCommand(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            PlayerCode: source.PlayerCode,
            UserName: source.UserName,
            Currency: source.Currency,
            BetLimit: source.BetLimit,
            Language: source.Language);

        return service.ExecuteAsync(
            command: command,
            cancellationToken: HttpContext.RequestAborted);
    }
}
