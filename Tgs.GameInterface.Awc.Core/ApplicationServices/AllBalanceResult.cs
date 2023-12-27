namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

public record AllBalanceResult(
    string PlayerCode,
    decimal Balance,
    DateTimeOffset LastModified);
