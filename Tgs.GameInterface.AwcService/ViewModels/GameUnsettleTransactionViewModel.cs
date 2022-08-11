namespace Tgs.GameInterface.AwcService.ViewModels;

public record GameUnsettleTransactionViewModel(
    string ExternalRoundId,
    string Platform,
    string PlatformTxId,
    string GameType,
    string GameCode,
    string GameName,
    string RoundId,
    string UserId,
    string Currency,
    string BetTime,
    string BetType,
    decimal BetAmount,
    decimal RealBetAmount,
    decimal JackpotBetAmount,
    string GameInfo);
