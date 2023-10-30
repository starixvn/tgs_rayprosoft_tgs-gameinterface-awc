namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record GameRecordUnsettledQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string Platform,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
