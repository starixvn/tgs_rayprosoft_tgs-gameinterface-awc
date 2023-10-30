namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record GameRecordByUpdateQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string Platform,
    DateTimeOffset TimeFrom);
