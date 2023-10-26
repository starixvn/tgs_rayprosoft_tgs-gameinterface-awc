namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record PlayerBalanceResult(
    bool IsPlayerExist,
    decimal Balance);
