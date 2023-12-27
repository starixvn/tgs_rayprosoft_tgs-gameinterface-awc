using System;

namespace Tgs.GameInterface.Awc.Core;

internal class GameWagerUtensil : IGameWagerUtensil
{
    /// <summary>
    /// Determines whether the specified tx status is canceled.
    /// </summary>
    /// <param name="txStatus">The tx status.</param>
    /// <returns>
    ///   <c>true</c> if the specified tx status is canceled; otherwise, <c>false</c>.
    ///   txStatus is -1
    ///   取消投注，超时或系统错误时会发生
    ///   仅支持JDB SLOT/ JDB FISH / YL FISH / FC / JILI SLOT / JILI FISH / SPADE FISH / PG
    ///   (支援取消结算并取消注单之平台)
    ///
    ///   txStatus is 2
    ///   注单无效，当有问题发生在该局或是该注单时
    ///
    ///   txStatus is 3
    ///   赛马游戏割马后退回的金额
    ///
    ///   txStatus is 5
    ///   因赛马规则限制退还下注「位置 Place」的交易 (仅支持 HORSEBOOK)
    ///
    ///   txStatus is 9
    ///   斗鸡 (SV388) 无效的交易，不会在后台报表呈现
    /// </returns>
    public bool IsCanceled(int txStatus)
        => txStatus is not 1;

    /// <summary>
    /// Determines whether the specified tx status is cashout.
    /// </summary>
    /// <param name="txStatus">The tx status.</param>
    /// <returns>
    ///   <c>true</c> if the specified tx status is cashout; otherwise, <c>false</c>.
    ///   txStatus is 3
    ///   赛马游戏割马后退回的金额
    ///   txStatus is 5
    ///   因赛马规则限制退还下注「位置 Place」的交易 (仅支持 HORSEBOOK)
    /// </returns>
    public bool IsCashout(int txStatus)
        => txStatus is 3 or 5;

    /// <summary>
    /// Determines whether the specified tx status is closed.
    /// </summary>
    /// <param name="txStatus">The tx status.</param>
    /// <returns>
    ///   <c>true</c> if the specified tx status is closed; otherwise, <c>false</c>.
    /// </returns>
    public bool IsClosed(int txStatus)
        => txStatus is not 0;

    /// <summary>
    /// Determines whether the specified tx status is void.
    /// </summary>
    /// <param name="txStatus">The tx status.</param>
    /// <param name="settleStatus">The settle status.</param>
    /// <returns>
    ///   <c>true</c> if the specified tx status is void; otherwise, <c>false</c>.
    ///   bet ➔ settle ➔ voidSettle
    ///   下注 ➔ 派彩 ➔ 注单无效
    /// </returns>
    public bool IsVoid(int txStatus, int settleStatus)
        => txStatus is 2 && settleStatus is 1;
}
