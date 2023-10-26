namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record PlayerBalanceQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode);
