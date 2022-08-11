namespace Tgs.GameInterface.AwcService.ViewModels;

public record GameSettleQueryViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
