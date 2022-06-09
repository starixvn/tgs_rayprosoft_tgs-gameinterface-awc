namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record BalanceResultViewModel(
        bool Success,
        string? Message,
        bool IsPlayerExist,
        decimal? Balance);
}
