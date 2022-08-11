using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

internal class LogoutCommandService : ICommandService<LogoutCommand>
{
    private readonly IGameApiClient _client;

    public LogoutCommandService(IGameApiClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public ValueTask ExecuteAsync(LogoutCommand command, CancellationToken cancellationToken = default)
        => _client.LogoutAsync(
            command.ApiUrl,
            command.AgentId,
            command.Cert,
            command.PlayerCode,
            cancellationToken);
}
