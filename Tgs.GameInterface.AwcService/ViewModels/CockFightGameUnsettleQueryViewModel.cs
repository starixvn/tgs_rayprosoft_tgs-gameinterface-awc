namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record CockFightGameUnsettleQueryViewModel(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        DateTimeOffset TimeFrom);
}
