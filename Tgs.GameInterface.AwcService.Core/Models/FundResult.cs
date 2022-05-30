namespace Tgs.GameInterface.AwcService.Core.Models
{
    public record FundResult(
        bool Success,
        string TransactionId,
        string GameProductTransactionId,
        decimal Amount,
        decimal CurrentBalance);
}
