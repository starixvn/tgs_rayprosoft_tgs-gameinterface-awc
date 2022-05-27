namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record CreatePlayerByLiveViewModel(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        string UserName,
        string Currency,
        string BetLimit,
        string Language = "en");
}
