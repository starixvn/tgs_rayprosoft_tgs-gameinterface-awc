using Tgs.ServiceUtility;
using Tgs.GameInterface.Awc.Core;
using Tgs.GameInterface.Awc.Core.ApplicationServices;

namespace Tgs.GameInterface.Awc.Core.ApplicationServices;

internal class LogoutCommandService(IGameApiClient client) : ICommandService<LogoutCommand>
{
    public ValueTask ExecuteAsync(LogoutCommand command, CancellationToken cancellationToken = default)
        => client.LogoutAsync(
            command.ApiUrl,
            command.AgentId,
            command.Cert,
            command.PlayerCode,
            cancellationToken);
}
