using Tgs.ServiceUtility;
using Tgs.GameInterface.Awc.Core;
using Tgs.GameInterface.Awc.Core.ApplicationServices;

namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

internal class FundInGetService(IGameApiClient client) : IGetService<FundInQuery, FundResult>
{
    public async ValueTask<FundResult> GetAsync(FundInQuery query, CancellationToken cancellationToken = default)
    {
        var result = await client.WithdrawAsync(
            apiUrl: query.ApiUrl,
            agentId: query.AgentId,
            cert: query.Cert,
            playerCode: query.PlayerCode,
            transactionId: query.OrderId,
            amount: query.Amount,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return new FundResult(
            OrderId: result.TransactionId,
            GameProviderTransactionId: result.GameProviderTransactionId,
            Amount: result.Amount,
            CurrentBalance: result.CurrentBalance,
            Resp: result.Resp);
    }
}
