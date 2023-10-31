using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Interfaces;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Controllers;

[Route("AWC_YL")]
[ApiController]
public class YouLianController : AwcController,
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
    ///             "agentId": "cnygpiyl",
    ///             "cert": "lsOJIO5ejew2DYfjTDV",
    ///             "timeFrom": "2022-06-01T08:00:00.000Z"
    ///         }
    ///
    /// </remarks>
    public override async IAsyncEnumerable<GamePullRecordResultViewModel> GameRecordPullAsync(
        [FromServices] IQueryService<GameRecordSettledQuery, GameRecordResult> service,
        GamePullRecordQueryViewModel source)
    {
        var query = new GameRecordSettledQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            Platform: AwcPlatforms.AWC_YL,
            TimeFrom: source.TimeFrom);

        var result = await service.QueryAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordResult>();

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
                GameInfo: transaction.GameInfo,
                AdditionalData: transaction.AdditionalData);
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
    ///             "agentId": "cnygpiyl",
    ///             "cert": "lsOJIO5ejew2DYfjTDV",
    ///             "startTime": "2022-06-10T05:30:00.000Z",
    ///             "endTime": "2022-06-10T06:30:00.000Z"
    ///         }
    ///
    /// </remarks>
    public override async IAsyncEnumerable<GameTransactionViewModel> GameRecordSettledAsync(
        [FromServices] IQueryService<GameRecordQuery, GameRecordResult> service,
        GameSettleQueryViewModel source)
    {
        var query = new GameRecordQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            Platform: AwcPlatforms.AWC_YL,
            StartTime: source.StartTime,
            EndTime: source.EndTime);

        var result = await service.QueryAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordResult>();

        if (!result.Any())
        {
            yield break;
        }

        foreach (var transaction in result)
        {
            yield return new GameTransactionViewModel(
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
                GameInfo: transaction.GameInfo,
                AdditionalData: transaction.AdditionalData);
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
    ///             "agentId": "cnygpiyl",
    ///             "cert": "lsOJIO5ejew2DYfjTDV",
    ///             "playerCode": "4ucmqplxb029",
    ///             "isMobileLogin": false,
    ///             "backUrl": "https://dev-t1.rpgp.cc/",
    ///             "externalGameId": "YL-EGAME-001",
    ///             "language": "cn"
    ///         }
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://tttint.onlinegames22.com/",
    ///             "agentId": "cnygpiyl",
    ///             "cert": "lsOJIO5ejew2DYfjTDV",
    ///             "playerCode": "4ucmqplxb029",
    ///             "isMobileLogin": false,
    ///             "backUrl": "https://dev-t1.rpgp.cc/",
    ///             "externalGameId": "YL-FISH-001",
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
            Platform: AwcPlatforms.AWC_YL,
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
    ///             "agentId": "cnygpiyl",
    ///             "cert": "lsOJIO5ejew2DYfjTDV",
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
