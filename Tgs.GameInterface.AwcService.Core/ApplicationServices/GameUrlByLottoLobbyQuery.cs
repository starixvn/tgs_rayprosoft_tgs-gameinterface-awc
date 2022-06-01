namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record GameUrlByLottoLobbyQuery(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        bool IsMobileLogin,
        string BackUrl,
        string Platform,
        string Language);
}
