namespace Tgs.GameInterface.AwcService.Core.Models;

public record LoginAndLaunchGameResult(
    bool IsPlayerExist,
    string GameUrl);
