using Tgs.GameInterface.Awc.Core.Models;

using Tgs.ServiceUtility;

namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

internal class GameUrlGetService(IGameApiClient client) : IGetService<GameUrlQuery, GameUrlResult>
{
    public async ValueTask<GameUrlResult> GetAsync(GameUrlQuery query, CancellationToken cancellationToken = default)
    {
        var gameCodeSplits = query.ExternalGameId.Split("-");
        var gameType = gameCodeSplits[1].ToUpper() switch
        {
            "SLOT" => AwcGameTypes.SLOT.ToString(),
            "FISH" => AwcGameTypes.FH.ToString(),
            "FH" => AwcGameTypes.FH.ToString(),
            "EGAME" => AwcGameTypes.EGAME.ToString(),
            "TABLE" => AwcGameTypes.TABLE.ToString(),
            "LOTTO" => AwcGameTypes.LOTTO.ToString(),
            "BINGO" => AwcGameTypes.BINGO.ToString(),
            _ => throw new NotImplementedException(),
        };

        var data = new LoginAndLaunchGame(
            PlayerCode: query.PlayerCode,
            IsMobileLogin: query.IsMobileLogin,
            BackUrl: query.BackUrl,
            Platform: query.Platform,
            GameType: gameType,
            ExternalGameId: query.ExternalGameId,
            Language: query.Language);

        var result = await client.LoginAndLaunchGameAsync(
            apiUrl: query.ApiUrl,
            agentId: query.AgentId,
            cert: query.Cert,
            data: data,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return new GameUrlResult(
            IsPlayerExist: result.IsPlayerExist,
            GameUrl: result.GameUrl);
    }
}
