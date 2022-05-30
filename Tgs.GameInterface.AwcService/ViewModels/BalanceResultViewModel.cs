namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record BalanceResultViewModel(
        bool Success,
        bool IsPlayerExist,
        decimal? Balance);
}
