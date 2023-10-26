namespace Tgs.GameInterface.AwcService.Core.Models;

public record BalanceInfo(
    string UserId,
    decimal Balance,
    DateTimeOffset LastModified);
