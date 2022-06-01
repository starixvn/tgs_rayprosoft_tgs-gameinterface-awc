namespace Tgs.GameInterface.AwcService.Core.Models
{
    public record GetTransactionByTxTimeTransaction
    {
        /// <summary>
        /// The platform(游戏平台名称)
        /// </summary>
        public string Platform { get; set; } = default!;
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
        /// The tx status(交易状态)
        /// 若无带入参数则默认回传数值包含以下：
        /// -1 Canceled 已取消投注※
        /// 1 Settled 已结账
        /// 2 Void 注单无效
        /// 3 SCRATCH in Horsebook 赛马游戏割马后退回的金额
        /// 5 Refund bet of Place in HRB 退还赛马交易下注"位置"的金额
        /// 9 Invalid 无效交易
        /// ※:Please check Supported Platforms of "Canceled" from 8.6.Transaction status
        /// ※:"已取消投注" 支持的游戏平台请参考8.6.交易类型
        /// </summary>
        public int TxStatus { get; set; }
        /// <summary>
        /// The settle status
        /// 用于区分注单结果是否有更改
        ///     正常状况：
        ///         预设：0
        ///     结果更改过状况：
        ///         Unsettle / Voidsettle / Unvoidsettle: 1
        ///         Voidbet: -1
        /// </summary>
        public int SettleStatus { get; set; }
        /// <summary>
        /// The bet time(玩家下注时间)
        /// </summary>
        public string BetTime { get; set; } = default!;
        /// <summary>
        /// The tx time(辨认交易时间依据 (遵循 ISO8601 格式))
        /// </summary>
        public string TxTime { get; set; } = default!;
        /// <summary>
        /// The update time(更新时间 (遵循 ISO8601 格式))
        /// </summary>
        public string UpdateTime { get; set; } = default!;
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
        /// The turnover(游戏平台有效投注)
        /// </summary>
        public decimal Turnover { get; set; }
        /// <summary>
        /// The win amount(返还金额 (包含下注金额))
        /// </summary>
        public decimal WinAmount { get; set; }
        /// <summary>
        /// The real win amount(真实返还金额)
        /// </summary>
        public decimal RealWinAmount { get; set; }
        /// <summary>
        /// The jackpot bet amount(累积奖金的下注金额)
        /// ※AWC do not support jackpot yet
        /// ※AWC 目前尚未支持 jackpot
        /// </summary>
        public decimal JackpotBetAmount { get; set; }
        /// <summary>
        /// The jackpot win amount(累积奖金的获胜金额)
        /// ※AWC do not support jackpot yet
        /// ※AWC 目前尚未支持 jackpot
        /// </summary>
        public decimal JackpotWinAmount { get; set; }
        /// <summary>
        /// The game information(游戏讯息会由游戏商以 JSON 格式提供)
        /// </summary>
        public string GameInfo { get; set; } = default!;
    }
}
