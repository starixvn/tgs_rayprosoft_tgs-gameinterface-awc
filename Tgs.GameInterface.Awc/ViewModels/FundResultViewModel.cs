namespace Tgs.GameInterface.Awc.ViewModels;

public record FundResultViewModel(
    string TransactionId,
    string GameProductTransactionId,
    decimal Amount,
    decimal CurrentBalance,
    string Resp);
