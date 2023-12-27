namespace Tgs.GameInterface.Awc.ViewModels;

public record GameUrlQueryViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string PlayerCode,
    bool IsMobileLogin,
    string BackUrl,
    string ExternalGameId,
    string Language);
