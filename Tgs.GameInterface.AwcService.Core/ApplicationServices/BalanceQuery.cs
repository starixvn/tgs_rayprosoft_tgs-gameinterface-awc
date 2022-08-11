namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record BalanceQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode);
