namespace Tgs.GameInterface.AwcService.Core.Models
{
    public record GetTransactionByTxTimeResult(
        bool Success,
        string? Message = null,
        IEnumerable<GetTransactionByTxTimeTransaction>? Transactions = null);
}
