namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record BalanceResult(
        bool Success,
        bool IsPlayerExist,
        decimal? Balance);
}
