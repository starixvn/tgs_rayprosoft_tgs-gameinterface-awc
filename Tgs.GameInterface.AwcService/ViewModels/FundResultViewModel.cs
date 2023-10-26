namespace Tgs.GameInterface.AwcService.ViewModels;

public record FundResultViewModel(
    string TransactionId,
    string GameProductTransactionId,
    decimal Amount,
    decimal CurrentBalance,
    string Resp);
