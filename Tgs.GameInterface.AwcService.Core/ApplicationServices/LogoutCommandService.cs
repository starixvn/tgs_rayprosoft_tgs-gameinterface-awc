using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

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
