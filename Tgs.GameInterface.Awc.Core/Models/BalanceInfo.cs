namespace Tgs.GameInterface.Awc.Core.Models;

public record BalanceInfo(
    string UserId,
    decimal Balance,
    DateTimeOffset LastModified);
