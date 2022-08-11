namespace Tgs.GameInterface.AwcService.ViewModels;

public record CreatePlayerByBetLimitViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode,
    string UserName,
    string Currency,
    string BetLimit,
    string Language = "en");
