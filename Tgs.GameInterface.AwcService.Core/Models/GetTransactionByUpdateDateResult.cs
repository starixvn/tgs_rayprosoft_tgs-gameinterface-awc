namespace Tgs.GameInterface.AwcService.Core.Models;

public record GetTransactionByUpdateDateResult(
    bool Success,
    IEnumerable<GetTransactionByUpdateDateTransaction> Transactions,
    string? Message = null);
