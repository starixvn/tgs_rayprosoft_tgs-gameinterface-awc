namespace Tgs.GameInterface.Awc.ViewModels;

public record GameSettleQueryViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
