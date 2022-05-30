namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record GameUrlByLottoLobbyQueryViewModel(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        bool IsMobileLogin,
        string ExternalURL,
        string Language);
}
