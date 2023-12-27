namespace Tgs.GameInterface.Awc.ViewModels;

public record GameWagerResultViewModel(
    string ExternalRoundId,
    string ExternalWagerId,
    string ExternalGameId,
    string PlayerCode,
    bool IsClosed,
    bool IsCanceled,
    bool IsVoid,
    bool IsCashout,
    DateTimeOffset ExternalCreatedOn,
    DateTimeOffset ExternalClosedOn,
    decimal Bet,
    decimal ValidBet,
    decimal Settle,
    decimal Turnover,
    decimal WinLoss,
    string AdditionalData);
