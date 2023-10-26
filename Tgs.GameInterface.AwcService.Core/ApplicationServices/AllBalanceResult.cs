namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record AllBalanceResult(
    string PlayerCode,
    decimal Balance,
    DateTimeOffset LastModified);
