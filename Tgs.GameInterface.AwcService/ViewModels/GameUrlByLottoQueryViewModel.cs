namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record GameUrlByLottoQueryViewModel(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        bool IsMobileLogin,
        string ExternalURL,
        string Language);
}
