namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record TransactionByTxTimeQuery(
    Uri ApiUrl,
    string AgentId,
    string Cert,
    string Platform,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
