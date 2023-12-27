namespace Tgs.GameInterface.Awc.ViewModels;

public record FundOrderCheckingViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string OrderId);
