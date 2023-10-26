namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record GameRecordPullQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string Platform,
    DateTimeOffset TimeFrom);
