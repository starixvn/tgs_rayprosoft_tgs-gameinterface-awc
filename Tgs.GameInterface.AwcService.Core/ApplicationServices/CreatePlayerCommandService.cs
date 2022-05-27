using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    internal class CreatePlayerCommandService : ICommandService<CreatePlayerCommand>
    {
        private readonly IGameApiClient _client;

        public CreatePlayerCommandService(IGameApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public ValueTask ExecuteAsync(CreatePlayerCommand command, CancellationToken cancellationToken = default)
            => _client.CreatePlayerAsync(
                command.ApiUrl,
                command.AgentId,
                command.Cert,
                command.PlayerCode,
                command.UserName,
                command.Currency,
                command.Language,
                cancellationToken);
    }
}
