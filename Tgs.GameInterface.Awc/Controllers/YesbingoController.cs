using Microsoft.AspNetCore.Mvc;
using Tgs.ServiceUtility;
using Tgs.GameInterface.Awc.Core;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.Controllers;
using Tgs.GameInterface.Awc.Interfaces;
using Tgs.GameInterface.Awc.ViewModels;

namespace Tgs.GameInterface.Awc.Controllers;

[Route("AWC_YESBINGO")]
[ApiController]
public class YesbingoController : AwcController,
    IGameUrlHandler,
    IPlayerCreateHandler
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
    ///             "agentId": "cnygpiyesbingo",
    ///             "cert": "K6o8NgepzBGRoGorvbQ",
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
            Platform: AwcPlatforms.AWC_YESBINGO,
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
    ///             "agentId": "cnygpiyesbingo",
    ///             "cert": "K6o8NgepzBGRoGorvbQ",
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
            Platform: AwcPlatforms.AWC_YESBINGO,
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
    /// Games the URL asynchronous.
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
    ///             "agentId": "cnygpiyesbingo",
    ///             "cert": "K6o8NgepzBGRoGorvbQ",
    ///             "playerCode": "4ucmqplxb029",
    ///             "isMobileLogin": false,
    ///             "backUrl": "https://dev-t1.rpgp.cc/",
    ///             "externalGameId": "YesBingo-SLOT-001",
    ///             "language": "cn"
    ///         }
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpiyesbingo",
    ///             "cert": "K6o8NgepzBGRoGorvbQ",
    ///             "playerCode": "4ucmqplxb029",
    ///             "isMobileLogin": false,
    ///             "backUrl": "https://dev-t1.rpgp.cc/",
    ///             "externalGameId": "YesBingo-BINGO-001",
    ///             "language": "cn"
    ///         }
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpiyesbingo",
    ///             "cert": "K6o8NgepzBGRoGorvbQ",
    ///             "playerCode": "4ucmqplxb029",
    ///             "isMobileLogin": false,
    ///             "backUrl": "https://dev-t1.rpgp.cc/",
    ///             "externalGameId": "YesBingo-FH-001",
    ///             "language": "cn"
    ///         }
    /// </remarks>
    [HttpPost("game/url")]
    public async ValueTask<GameUrlResultViewModel> GameUrlAsync(
        [FromServices] IGetService<GameUrlQuery, GameUrlResult> service,
        GameUrlQueryViewModel source)
    {
        var query = new GameUrlQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            PlayerCode: source.PlayerCode,
            IsMobileLogin: source.IsMobileLogin,
            BackUrl: source.BackUrl,
            Platform: AwcPlatforms.AWC_YESBINGO,
            ExternalGameId: source.ExternalGameId,
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
    ///             "agentId": "cnygpiyesbingo",
    ///             "cert": "K6o8NgepzBGRoGorvbQ",
    ///             "playerCode": "4ucmqplxb029",
    ///             "userName": "4ucmqplxb029",
    ///             "currency": "CNY",
    ///             "language": "cn"
    ///         }
    /// </remarks>
    [HttpPost("player/create")]
    public ValueTask PlayerCreateAsync(
        [FromServices] ICommandService<PlayerCreateCommand> service,
        CreatePlayerViewModel source)
    {
        var command = new PlayerCreateCommand(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            PlayerCode: source.PlayerCode,
            UserName: source.UserName,
            Currency: source.Currency,
            Language: source.Language);

        return service.ExecuteAsync(
            command: command,
            cancellationToken: HttpContext.RequestAborted);
    }
}
