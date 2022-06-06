namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record FundResultViewModel(
        bool Success,
        string? Message,
        string? TransactionId,
        string? GameProductTransactionId,
        decimal? Amount,
        decimal? CurrentBalance);
}
