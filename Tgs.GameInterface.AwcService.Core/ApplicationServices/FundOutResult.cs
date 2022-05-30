namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record FundOutResult(
        bool Success,
        string TransactionId,
        string GameProductTransactionId,
        decimal Amount,
        decimal CurrentBalance);
}
