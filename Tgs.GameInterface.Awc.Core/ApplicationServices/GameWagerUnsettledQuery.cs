namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

public record GameWagerUnsettledQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string Platform,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
