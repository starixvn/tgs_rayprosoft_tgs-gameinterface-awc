namespace Tgs.GameInterface.Awc.ViewModels;

public record PlayerLogoutViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode);
