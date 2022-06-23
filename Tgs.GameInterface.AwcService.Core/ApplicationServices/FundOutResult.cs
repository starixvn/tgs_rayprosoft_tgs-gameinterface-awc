namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record FundOutResult(
        bool Success,
        string? Message,
        string? TransactionId,
        string? GameProviderTransactionId,
        decimal? Amount,
        decimal? CurrentBalance);
}
