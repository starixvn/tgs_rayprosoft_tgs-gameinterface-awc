namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record FundOrderCheckingQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string TransactionId);
