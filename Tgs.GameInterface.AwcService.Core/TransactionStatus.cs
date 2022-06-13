namespace Tgs.GameInterface.AwcService.Core
{
    public enum TransactionStatus
    {
        Canceled = -1,
        Bet = 0,
        Settled = 1,
        Void = 2,
        SCRATCHInHorsebook = 3,
        RefundBetOfPlaceInHRB = 5,
        InvalidTransactionInSV388 = 9
    }
}
