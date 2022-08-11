namespace Tgs.GameInterface.AwcService.Core.Models;

public record GetTransactionByUpdateDateResult(
    bool Success,
    string? Message = null,
    IEnumerable<GetTransactionByUpdateDateTransaction>? Transactions = null);
