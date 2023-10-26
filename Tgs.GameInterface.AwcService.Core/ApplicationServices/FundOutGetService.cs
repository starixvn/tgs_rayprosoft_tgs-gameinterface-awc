using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

internal class FundOutGetService : IGetService<FundOutQuery, FundResult>
{
    private readonly IGameApiClient _client;

    public FundOutGetService(IGameApiClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<FundResult> GetAsync(FundOutQuery query, CancellationToken cancellationToken = default)
    {
        var result = await _client.DepositAsync(
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
