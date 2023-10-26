namespace Tgs.GameInterface.AwcService.ViewModels;

public record PlayerLogoutViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode);
