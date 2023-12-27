using Tgs.ServiceUtility;
using Tgs.GameInterface.Awc.Core;
using Tgs.GameInterface.Awc.Core.ApplicationServices;

namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

internal class FundStatusGetService(IGameApiClient client) : IGetService<FundStatusQuery, bool>
{
    public ValueTask<bool> GetAsync(FundStatusQuery command, CancellationToken cancellationToken = default)
        => client.CheckTransferOperationAsync(
            apiUrl: command.ApiUrl,
            agentId: command.AgentId,
            cert: command.Cert,
            transactionId: command.OrderId,
            cancellationToken: cancellationToken);
}
