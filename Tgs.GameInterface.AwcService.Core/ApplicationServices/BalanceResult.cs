namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record BalanceResult(
        bool Success,
        string? Message,
        bool IsPlayerExist,
        decimal? Balance);
}
