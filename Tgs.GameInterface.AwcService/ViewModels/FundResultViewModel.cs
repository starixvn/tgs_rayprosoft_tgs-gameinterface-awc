namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record FundResultViewModel(
        bool Success,
        string TransactionId,
        string GameProductTransactionId,
        decimal Amount,
        decimal CurrentBalance);
}
