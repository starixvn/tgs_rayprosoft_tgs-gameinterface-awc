namespace Tgs.GameInterface.AwcService.ViewModels;

public record GameRecordUnsettleByAwcCockfightViewModel(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    DateTimeOffset TimeFrom);
