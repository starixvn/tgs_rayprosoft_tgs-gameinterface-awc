namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

public record FundOutQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode,
    string OrderId,
    decimal Amount);
