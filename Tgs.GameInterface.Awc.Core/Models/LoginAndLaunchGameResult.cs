namespace Tgs.GameInterface.Awc.Core.Models;

public record LoginAndLaunchGameResult(
    bool IsPlayerExist,
    string GameUrl);
