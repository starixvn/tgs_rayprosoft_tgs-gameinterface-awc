namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record FundInResult(
        bool Success,
        string TransactionId,
        string GameProductTransactionId,
        decimal Amount,
        decimal CurrentBalance);
}
