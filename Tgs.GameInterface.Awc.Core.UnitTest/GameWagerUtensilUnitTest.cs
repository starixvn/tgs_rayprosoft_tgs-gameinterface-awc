namespace Tgs.GameInterface.Awc.Core.UnitTest;

public class GameWagerUtensilUnitTest
{
    /// <summary>
    /// Txes the status 0 is closed false.
    /// </summary>
    [Fact]
    public void TxStatus_0_Is_Closed_False()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsClosed(0);

        Assert.False(actual);
    }

    /// <summary>
    /// Txes the status 1 is canceled false.
    /// 已结账
    /// </summary>
    [Fact]
    public void TxStatus_1_Is_Canceled_False()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsCanceled(1);

        Assert.False(actual);
    }

    /// <summary>
    /// Txes the status 1 is closed true.
    /// </summary>
    [Fact]
    public void TxStatus_1_Is_Closed_True()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsClosed(2);

        Assert.True(actual);
    }

    [Fact]
    public void TxStatus_1_SettleStatus_1_Is_Void_False()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsVoid(1, 1);

        Assert.False(actual);
    }

    /// <summary>
    /// Txes the status 2 settle status 1 is void true.
    ///
    /// bet ➔ settle ➔ voidSettle
    /// 下注 ➔ 派彩 ➔ 注单无效
    /// </summary>
    [Fact]
    public void TxStatus_2_SettleStatus_1_Is_Void_True()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsVoid(2, 1);

        Assert.True(actual);
    }

    /// <summary>
    /// Txes the status 3 is canceled true.
    /// 赛马游戏割马后退回的金额
    /// </summary>
    [Fact]
    public void TxStatus_3_Is_Canceled_True()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsCanceled(3);

        Assert.True(actual);
    }

    /// <summary>
    /// Txes the status 3 is cashout false.
    /// 赛马游戏割马后退回的金额
    /// </summary>
    [Fact]
    public void TxStatus_3_Is_Cashout_False()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsCashout(3);

        Assert.True(actual);
    }

    /// <summary>
    /// Txes the status 5 is canceled false.
    /// 因赛马规则限制退还下注「位置 Place」的交易 (仅支持 HORSEBOOK)
    /// </summary>
    [Fact]
    public void TxStatus_5_Is_Canceled_False()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsCanceled(5);

        Assert.True(actual);
    }

    /// <summary>
    /// Txes the status 5 is cashout false.
    /// 因赛马规则限制退还下注「位置 Place」的交易 (仅支持 HORSEBOOK)
    /// </summary>
    [Fact]
    public void TxStatus_5_Is_Cashout_False()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsCashout(5);

        Assert.True(actual);
    }

    /// <summary>
    /// Txes the status negative 1 is canceled true.
    /// 取消投注，超时或系统错误时会发生
    /// 仅支持JDB SLOT/ JDB FISH / YL FISH / FC / JILI SLOT / JILI FISH / SPADE FISH / PG
    /// (支援取消结算并取消注单之平台)
    /// </summary>
    [Fact]
    public void TxStatus_Negative_1_Is_Canceled_True()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsCanceled(-1);

        Assert.True(actual);
    }

    /// <summary>
    /// Txes the status negative 2 is canceled true.
    /// 注单无效，当有问题发生在该局或是该注单时
    /// </summary>
    [Fact]
    public void TxStatus_Negative_2_Is_Canceled_True()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsCanceled(2);

        Assert.True(actual);
    }

    /// <summary>
    /// Txes the status negative 9 is canceled true.
    /// 斗鸡 (SV388) 无效的交易，不会在后台报表呈现
    /// </summary>
    [Fact]
    public void TxStatus_Negative_9_Is_Canceled_True()
    {
        var repository = new GameWagerUtensil();

        var actual = repository.IsCanceled(9);

        Assert.True(actual);
    }
}
