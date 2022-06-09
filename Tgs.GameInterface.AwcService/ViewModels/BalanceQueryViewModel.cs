namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record BalanceQueryViewModel(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode);
}
