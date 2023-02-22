namespace Tgs.GameInterface.AwcService.Core.Models;

public record GetTransactionByTxTimeResult(
    bool Success,
    IEnumerable<GetTransactionByTxTimeTransaction> Transactions,
    string? Message = null);
