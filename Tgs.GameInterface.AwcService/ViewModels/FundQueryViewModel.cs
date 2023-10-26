namespace Tgs.GameInterface.AwcService.ViewModels;

public record FundQueryViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode,
    string OrderId,
    decimal Amount);
