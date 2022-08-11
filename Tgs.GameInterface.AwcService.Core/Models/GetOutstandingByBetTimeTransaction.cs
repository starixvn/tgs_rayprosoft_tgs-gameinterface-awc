namespace Tgs.GameInterface.AwcService.Core.Models;

public record GetOutstandingByBetTimeTransaction
{
    /// <summary>
    /// The platform tx identifier(游戏商注单号)
    /// 如果您需要唯一值，请使用 platform + platformTxId
    /// </summary>
    public string PlatformTxId { get; set; } = default!;
    /// <summary>
    /// The game type(平台游戏类型)
    /// </summary>
    public string GameType { get; set; } = default!;
    /// <summary>
    /// The game code(平台游戏代码)
    /// </summary>
    public string GameCode { get; set; } = default!;
    /// <summary>
    /// The game name(游戏名称)
    /// </summary>
    public string GameName { get; set; } = default!;
    /// <summary>
    /// The round identifier(游戏商的回合识别码)
    /// </summary>
    public string RoundId { get; set; } = default!;
    /// <summary>
    ///  玩家 ID
    /// </summary>
    public string UserId { get; set; } = default!;
    /// <summary>
    /// The currency(玩家货币代码)
    /// </summary>
    public string Currency { get; set; } = default!;
    /// <summary>
    /// The bet time(玩家下注时间)
    /// </summary>
    public string BetTime { get; set; } = default!;
    /// <summary>
    /// The bet type(游戏平台的下注项目)
    /// </summary>
    public string BetType { get; set; } = default!;
    /// <summary>
    /// The bet amount(下注金额)
    /// </summary>
    public decimal BetAmount { get; set; }
    /// <summary>
    /// The real bet amount(真实下注金额)
    /// </summary>
    public decimal RealBetAmount { get; set; }
    /// <summary>
    /// The jackpot bet amount(累积奖金的下注金额)
    /// ※AWC do not support jackpot yet
    /// ※AWC 目前尚未支持 jackpot
    /// </summary>
    public decimal JackpotBetAmount { get; set; }
    /// <summary>
    /// The game information(游戏讯息会由游戏商以 JSON 格式提供)
    /// </summary>
    public string GameInfo { get; set; } = default!;
}
