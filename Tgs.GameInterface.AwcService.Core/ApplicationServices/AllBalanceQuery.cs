namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record AllBalanceQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert);
