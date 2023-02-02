namespace Tgs.GameInterface.AwcService.Core.Models;

public record AllBalance(
    string UserId,
    decimal Balance,
    DateTime LastModified);
