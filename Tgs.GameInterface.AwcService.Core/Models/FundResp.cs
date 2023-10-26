namespace Tgs.GameInterface.AwcService.Core.Models;

public record FundResp(
    string TransactionId,
    string GameProviderTransactionId,
    decimal Amount,
    decimal CurrentBalance,
    string Resp);
