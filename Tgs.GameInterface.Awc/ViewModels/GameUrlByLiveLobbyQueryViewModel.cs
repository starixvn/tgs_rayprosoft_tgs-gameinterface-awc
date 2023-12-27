namespace Tgs.GameInterface.Awc.ViewModels;

public record GameUrlByLiveLobbyQueryViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode,
    bool IsMobileLogin,
    string BackUrl,
    string BetLimit,
    string Language);
