using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    internal class FundOutGetService : IGetService<FundOutQuery, FundOutResult>
    {
        private readonly IGameApiClient _client;

        public FundOutGetService(IGameApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async ValueTask<FundOutResult> GetAsync(FundOutQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _client.DepositAsync(
                query.ApiUrl,
                query.AgentId,
                query.Cert,
                query.PlayerCode,
                query.TransactionId,
                query.Amount,
                cancellationToken).ConfigureAwait(false);

            return new FundOutResult(
                Success: result.Success,
                Message: result.Message,
                TransactionId: result.TransactionId,
                GameProviderTransactionId: result.GameProviderTransactionId,
                Amount: result.Amount,
                CurrentBalance: result.CurrentBalance);
        }
    }
}
