namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

public record PlayerBalanceQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode);
