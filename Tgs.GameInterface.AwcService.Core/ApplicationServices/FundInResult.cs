namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record FundInResult(
    bool Success,
    string? Message,
    string? TransactionId,
    string? GameProviderTransactionId,
    decimal? Amount,
    decimal? CurrentBalance);
