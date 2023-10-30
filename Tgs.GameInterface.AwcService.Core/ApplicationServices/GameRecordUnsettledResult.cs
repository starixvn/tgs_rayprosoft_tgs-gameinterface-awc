namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record GameRecordUnsettledResult(
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
    string GameInfo,
    string AdditionalData);
