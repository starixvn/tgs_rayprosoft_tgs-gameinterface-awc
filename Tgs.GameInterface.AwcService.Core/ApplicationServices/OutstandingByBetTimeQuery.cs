namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record OutstandingByBetTimeQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string Platform,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
