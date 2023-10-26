namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record FundInQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode,
    string OrderId,
    decimal Amount);
