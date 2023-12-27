namespace Tgs.GameInterface.Awc.Core;

public interface IGameWagerUtensil
{
    bool IsCanceled(int txStatus);

    bool IsCashout(int txStatus);

    bool IsClosed(int txStatus);

    bool IsVoid(int txStatus, int settleStatus);
}
