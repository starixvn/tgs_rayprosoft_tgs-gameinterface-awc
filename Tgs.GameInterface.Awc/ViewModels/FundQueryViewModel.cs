namespace Tgs.GameInterface.Awc.ViewModels;

public record FundQueryViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode,
    string OrderId,
    decimal Amount);
