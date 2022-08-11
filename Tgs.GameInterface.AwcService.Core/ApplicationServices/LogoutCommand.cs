namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record LogoutCommand(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode);
