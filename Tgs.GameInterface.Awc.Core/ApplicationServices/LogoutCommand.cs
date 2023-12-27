namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

public record LogoutCommand(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode);
