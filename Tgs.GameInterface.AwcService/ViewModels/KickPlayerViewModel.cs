namespace Tgs.GameInterface.AwcService.ViewModels;

public record KickPlayerViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode);
