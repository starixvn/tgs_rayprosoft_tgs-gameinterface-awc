namespace Tgs.GameInterface.AwcService.ViewModels;

public record AllBalanceViewModel(
    string UserId,
    decimal Balance,
    DateTime LastModified);
