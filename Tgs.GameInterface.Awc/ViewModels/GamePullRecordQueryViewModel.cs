namespace Tgs.GameInterface.Awc.ViewModels;

public record GamePullRecordQueryViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    DateTimeOffset TimeFrom);
