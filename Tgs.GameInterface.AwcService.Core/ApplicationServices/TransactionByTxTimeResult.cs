namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record TransactionByTxTimeResult(
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
        string BetTime,
        string TxTime,
        string UpdateTime,
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
