namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record GameRecordQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string Platform,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
