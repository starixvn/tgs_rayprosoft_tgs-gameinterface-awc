namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record GameUrlByLiveQueryViewModel(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        bool IsMobileLogin,
        string ExternalURL,
        string BetLimit,
        string Language);
}
