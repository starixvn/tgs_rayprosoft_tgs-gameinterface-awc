using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    internal class FundInGetService : IGetService<FundInQuery, FundInResult>
    {
        private readonly IGameApiClient _client;

        public FundInGetService(IGameApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async ValueTask<FundInResult> GetAsync(FundInQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _client.FundInAsync(
                query.ApiUrl,
                query.AgentId,
                query.Cert,
                query.PlayerCode,
                query.TransactionId,
                query.Amount,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            return new FundInResult(
                Success: result.Success,
                Message: result.Message,
                TransactionId: result.TransactionId,
                GameProductTransactionId: result.GameProductTransactionId,
                Amount: result.Amount,
                CurrentBalance: result.CurrentBalance);
        }
    }
}
