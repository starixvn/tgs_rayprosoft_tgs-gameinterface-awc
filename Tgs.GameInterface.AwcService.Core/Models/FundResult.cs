namespace Tgs.GameInterface.AwcService.Core.Models
{
    public record FundResult(
        bool Success,
        string? Message = null,
        string? TransactionId = null,
        string? GameProductTransactionId = null,
        decimal? Amount = null,
        decimal? CurrentBalance = null);
}
