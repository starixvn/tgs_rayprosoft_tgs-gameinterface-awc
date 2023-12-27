namespace Tgs.GameInterface.Awc.ViewModels;

public record AllBalanceViewModel(
    string PlayerCode,
    decimal Balance,
    DateTimeOffset LastModified);
