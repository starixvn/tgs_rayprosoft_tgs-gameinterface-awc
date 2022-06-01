namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record GameTransactionQuery(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string Platform,
        DateTimeOffset TimeFrom,
        TransactionStatus TransactionStatus);
}
