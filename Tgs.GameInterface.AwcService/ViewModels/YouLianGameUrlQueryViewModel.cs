namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record YouLianGameUrlQueryViewModel(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        bool IsMobileLogin,
        string ExternalURL,
        string GameCode,
        string Language);
}
