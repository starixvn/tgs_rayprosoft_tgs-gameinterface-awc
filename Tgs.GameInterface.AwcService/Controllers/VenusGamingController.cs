using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.AwcService.Core;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Interfaces;
using Tgs.GameInterface.AwcService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Controllers;

[Route("AWC_VENUS")]
[ApiController]
public class VenusGamingController : AwcController,
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
    ///             "agentId": "cnygpivenus",
    ///             "cert": "DfyfVhwJ8akfz2aGo3K",
    ///             "timeFrom": "2022-06-01T08:00:00.000Z"
    ///         }
    ///
    /// </remarks>
    public override async IAsyncEnumerable<GamePullRecordResultViewModel> GameRecordPullAsync(
        [FromServices] IQueryService<GameRecordPullQuery, GameRecordPullResult> service,
        GamePullRecordQueryViewModel source)
    {
        var query = new GameRecordPullQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            Platform: AwcPlatforms.AWC_VENUS,
            TimeFrom: source.TimeFrom);

        var result = await service.QueryAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordPullResult>();

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
    ///             "agentId": "cnygpivenus",
    ///             "cert": "DfyfVhwJ8akfz2aGo3K",
    ///             "startTime": "2022-06-10T05:30:00.000Z",
    ///             "endTime": "2022-06-10T06:30:00.000Z"
    ///         }
    ///
    /// </remarks>
    public override async IAsyncEnumerable<GameSettleTransactionViewModel> GameRecordSettledAsync(
        [FromServices] IQueryService<GameRecordSettledQuery, GameRecordSettledResult> service,
        GameSettleQueryViewModel source)
    {
        var query = new GameRecordSettledQuery(
            ApiUrl: source.ApiUrl,
            AgentId: source.AgentId,
            Cert: source.Cert,
            Platform: AwcPlatforms.AWC_VENUS,
            StartTime: source.StartTime,
            EndTime: source.EndTime);

        var result = await service.QueryAsync(
            query: query,
            cancellationToken: HttpContext.RequestAborted)
            .ToArrayAsync()
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordSettledResult>();

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
            Platform: AwcPlatforms.AWC_VENUS,
            ExternalGameId: "VN-LIVE-001",
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
    /// Players the create by bet limit asynchronous.
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
    ///             "agentId": "cnygpivenus",
    ///             "cert": "DfyfVhwJ8akfz2aGo3K",
    ///             "playerCode": "4ucmqplxb029",
    ///             "userName": "4ucmqplxb029",
    ///             "currency": "CNY",
    ///             "betLimit": "{\"VENUS\":{\"LIVE\":{\"limitId\":[280303,280304,280305]}}}",
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
