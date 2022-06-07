using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    internal class FundOrderCheckingGetService : IGetService<FundOrderCheckingQuery, bool>
    {
        private readonly IGameApiClient _client;

        public FundOrderCheckingGetService(IGameApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async ValueTask<bool> GetAsync(FundOrderCheckingQuery command, CancellationToken cancellationToken = default)
            => await _client.FundOrderCheckingAsync(
                apiUrl: command.ApiUrl,
                agentId: command.AgentId,
                cert: command.Cert,
                transactionId: command.TransactionId,
                cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}
