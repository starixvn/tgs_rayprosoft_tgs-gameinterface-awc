namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record FundStatusQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string OrderId);
