namespace Tgs.GameInterface.AwcService.Core.Models;

public record GetOutstandingByBetTimeResult(
    bool Success,
    IEnumerable<GetOutstandingByBetTimeTransaction> Transactions,
    string? Message = null);
