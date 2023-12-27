namespace Tgs.GameInterface.Awc.ViewModels;

public record GameRecordUnsettledViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
