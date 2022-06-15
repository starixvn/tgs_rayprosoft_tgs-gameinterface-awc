namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record TransactionByUpdateDateByStatusQuery(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string Platform,
        DateTimeOffset TimeFrom,
        TransactionStatus TransactionStatus);
}
