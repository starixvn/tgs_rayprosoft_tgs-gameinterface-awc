namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record GameSettleTransactionResult(
        string ExternalRoundId,
        string Platform,
        string PlatformTxId,
        string GameType,
        string GameCode,
        string GameName,
        string RoundId,
        string UserId,
        string Currency,
        int TxStatus,
        int SettleStatus,
        DateTimeOffset BetTime,
        DateTimeOffset TxTime,
        DateTimeOffset UpdateTime,
        string BetType,
        decimal BetAmount,
        decimal RealBetAmount,
        decimal Turnover,
        decimal WinAmount,
        decimal RealWinAmount,
        decimal JackpotBetAmount,
        decimal JackpotWinAmount,
        string GameInfo);
}
