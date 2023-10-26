namespace Tgs.GameInterface.AwcService.ViewModels;

public record AllBalanceViewModel(
    string PlayerCode,
    decimal Balance,
    DateTimeOffset LastModified);
