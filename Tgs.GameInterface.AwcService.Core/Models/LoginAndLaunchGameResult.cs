namespace Tgs.GameInterface.AwcService.Core.Models;

public record LoginAndLaunchGameResult(
    bool Success,
    string? Message = null,
    bool IsPlayerExist = false,
    string? GameUrl = null);
