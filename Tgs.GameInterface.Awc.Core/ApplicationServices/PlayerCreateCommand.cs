namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

public record PlayerCreateCommand(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode,
    string UserName,
    string Currency,
    string Language = "en");
