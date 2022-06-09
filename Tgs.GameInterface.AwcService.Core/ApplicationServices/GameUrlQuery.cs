namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record GameUrlQuery(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        bool IsMobileLogin,
        string BackUrl,
        string Platform,
        string ExternalGameId,
        string Language);
}
