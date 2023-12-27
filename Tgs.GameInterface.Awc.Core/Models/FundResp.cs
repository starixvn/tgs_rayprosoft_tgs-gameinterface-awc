namespace Tgs.GameInterface.Awc.Core.Models;

public record FundResp(
    string TransactionId,
    string GameProviderTransactionId,
    decimal Amount,
    decimal CurrentBalance,
    string Resp);
