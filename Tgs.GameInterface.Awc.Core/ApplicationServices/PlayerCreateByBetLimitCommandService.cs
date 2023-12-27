using Tgs.ServiceUtility;
using Tgs.GameInterface.Awc.Core;
using Tgs.GameInterface.Awc.Core.ApplicationServices;

namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

internal class PlayerCreateByBetLimitCommandService(IGameApiClient client) : ICommandService<PlayerCreateByBetLimitCommand>
{
    public ValueTask ExecuteAsync(PlayerCreateByBetLimitCommand command, CancellationToken cancellationToken = default)
        => client.CreatePlayerAsync(
            apiUrl: command.ApiUrl,
            agentId: command.AgentId,
            cert: command.Cert,
            playerCode: command.PlayerCode,
            userName: command.UserName,
            currency: command.Currency,
            betLimit: command.BetLimit,
            language: command.Language,
            cancellationToken: cancellationToken);
}
