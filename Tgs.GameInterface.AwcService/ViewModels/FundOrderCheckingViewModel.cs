namespace Tgs.GameInterface.AwcService.ViewModels;

public record FundOrderCheckingViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string TransactionId);
