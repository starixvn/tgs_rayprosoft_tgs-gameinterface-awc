namespace Tgs.GameInterface.AwcService.Core.Models
{
    public record GetBalanceResult(
        bool Success,
        string? Message = null,
        bool IsPlayerExist = false,
        decimal? Balance = null);
}
