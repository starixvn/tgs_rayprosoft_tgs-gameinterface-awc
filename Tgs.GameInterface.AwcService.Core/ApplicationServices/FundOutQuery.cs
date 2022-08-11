namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record FundOutQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode,
    string TransactionId,
    decimal Amount);
