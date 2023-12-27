namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

public record PlayerBalanceResult(
    bool IsPlayerExist,
    decimal Balance);
