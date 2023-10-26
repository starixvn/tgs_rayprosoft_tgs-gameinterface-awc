namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record PlayerCreateByBetLimitCommand(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode,
    string UserName,
    string Currency,
    string BetLimit,
    string Language = "en");
