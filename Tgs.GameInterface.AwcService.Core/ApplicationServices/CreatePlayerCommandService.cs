using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

internal class CreatePlayerCommandService : ICommandService<CreatePlayerCommand>
{
    private readonly IGameApiClient _client;

    public CreatePlayerCommandService(IGameApiClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public ValueTask ExecuteAsync(CreatePlayerCommand command, CancellationToken cancellationToken = default)
        => _client.CreatePlayerAsync(
            apiUrl: command.ApiUrl,
            agentId: command.AgentId,
            cert: command.Cert,
            playerCode: command.PlayerCode,
            userName: command.UserName,
            currency: command.Currency,
            language: command.Language,
            cancellationToken: cancellationToken);
}
