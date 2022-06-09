namespace Tgs.GameInterface.AwcService.ViewModels
{
    public record GameUnsettleQueryViewModel(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        DateTimeOffset StartTime,
        DateTimeOffset EndTime);
}
