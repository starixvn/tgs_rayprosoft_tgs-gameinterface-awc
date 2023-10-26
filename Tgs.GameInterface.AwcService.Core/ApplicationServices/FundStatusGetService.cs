using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

internal class FundStatusGetService : IGetService<FundStatusQuery, bool>
{
    private readonly IGameApiClient _client;

    public FundStatusGetService(IGameApiClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<bool> GetAsync(FundStatusQuery command, CancellationToken cancellationToken = default)
        => await _client.CheckTransferOperationAsync(
            apiUrl: command.ApiUrl,
            agentId: command.AgentId,
            cert: command.Cert,
            transactionId: command.OrderId,
            cancellationToken: cancellationToken).ConfigureAwait(false);
}
