namespace Tgs.GameInterface.Awc.ViewModels;

public record BalanceQueryViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode);
