namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

public record FundStatusQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string OrderId);
