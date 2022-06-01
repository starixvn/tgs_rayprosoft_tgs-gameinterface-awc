namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record CreatePlayerViewModel(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        string UserName,
        string Currency,
        string Language = "en");
}
