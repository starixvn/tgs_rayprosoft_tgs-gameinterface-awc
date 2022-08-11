namespace Tgs.GameInterface.AwcService.ViewModels;

public record GamePullRecordQueryViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    DateTimeOffset TimeFrom);
