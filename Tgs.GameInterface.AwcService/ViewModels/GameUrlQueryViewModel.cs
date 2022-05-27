namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record GameUrlQueryViewModel(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        bool IsMobileLogin,
        string ExternalURL,
        string GameType,
        string ExternalGameId,
        string Language);
}
