namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

public record GameWagerSettledQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string Platform,
    DateTimeOffset TimeFrom);
