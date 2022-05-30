namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record FundInQuery(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        string TransactionId,
        decimal Amount);
}
