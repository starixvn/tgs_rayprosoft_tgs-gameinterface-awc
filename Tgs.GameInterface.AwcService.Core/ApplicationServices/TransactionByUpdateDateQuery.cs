namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record TransactionByUpdateDateQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string Platform,
    DateTimeOffset TimeFrom);
