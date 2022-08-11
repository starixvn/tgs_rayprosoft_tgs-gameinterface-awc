namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record GameUrlByLiveLobbyQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode,
    bool IsMobileLogin,
    string BackUrl,
    string Platform,
    string BetLimit,
    string Language);
