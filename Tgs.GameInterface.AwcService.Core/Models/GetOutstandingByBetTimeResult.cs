namespace Tgs.GameInterface.AwcService.Core.Models
{
    public record GetOutstandingByBetTimeResult(
        bool Success,
        string? Message = null,
        IEnumerable<GetOutstandingByBetTimeTransaction>? Transactions = null);
}
