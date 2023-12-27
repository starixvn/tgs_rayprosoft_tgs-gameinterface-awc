using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.Awc.Core;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.Interfaces;
using Tgs.GameInterface.Awc.ViewModels;

using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Controllers;

[Route("AWC_COCKFIGHT")]
[ApiController]
public class CockFightController : AwcController,
    IGameUrlLobbyByLiveHandler,
    IPlayerCreateByBetLimitHandler
{
    /// <summary>
    /// Games the record pull asynchronous.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="source"></param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpicockfight",
    ///             "cert": "qsXFZmTNeLiMrNz1cIJ",
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
            Platform: AwcPlatforms.AWC_COCKFIGHT,
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
    /// <param name="service"></param>
    /// <param name="source"></param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpicockfight",
    ///             "cert": "qsXFZmTNeLiMrNz1cIJ",
    ///             "startTime": "2023-10-31T11:00:00+08:00",
    ///             "endTime": "2023-10-31T12:00:00+08:00"
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
            Platform: AwcPlatforms.AWC_COCKFIGHT,
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
    /// Games the record unsettled asynchronous.
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
    ///             "startTime": "2023-10-31T11:00:00+08:00",
    ///             "endTime": "2023-10-31T12:00:00+08:00"
    ///         }
    ///
    /// </remarks>
    [HttpPost("game/record/unsettled")]
    public async IAsyncEnumerable<GameWagerResultViewModel> GameRecordUnsettledAsync(
            [FromServices] IQueryService<GameWagerUnsettledQuery, GameWagerResult> service,
            GameRecordUnsettledViewModel source)
    {
        var query = new GameWagerUnsettledQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            Platform: AwcPlatforms.AWC_COCKFIGHT,
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
    /// Games the URL lobby by live asynchronous.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="source"></param>
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
    ///             "isMobileLogin": false,
    ///             "backUrl": "https://dev-t1.rpgp.cc/",
    ///             "betLimit": "{\"SV388\":{\"LIVE\":{\"maxbet\":2400,\"minbet\":1,\"mindraw\":1,\"matchlimit\":4800,\"maxdraw\":1200}}}",
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
            Platform: AwcPlatforms.AWC_COCKFIGHT,
            ExternalGameId: "SV-LIVE-001",
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
    /// Creates the player asynchronous.
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
    ///             "userName": "4ucmqplxb029",
    ///             "currency": "CNY",
    ///             "betLimit": "{\"SV388\":{\"LIVE\":{\"maxbet\":2400,\"minbet\":1,\"mindraw\":1,\"matchlimit\":4800,\"maxdraw\":1200}}}",
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
