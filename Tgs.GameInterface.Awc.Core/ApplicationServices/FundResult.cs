namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

public record FundResult(
    string OrderId,
    string GameProviderTransactionId,
    decimal Amount,
    decimal CurrentBalance,
    string Resp);
