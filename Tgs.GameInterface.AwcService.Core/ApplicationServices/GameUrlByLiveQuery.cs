namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record GameUrlByLiveQuery(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        bool IsMobileLogin,
        string ExternalURL,
        string Platform,
        string ExternalGameId,
        string BetLimit,
        string Language);
}
