namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

public record AllBalanceQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert);
