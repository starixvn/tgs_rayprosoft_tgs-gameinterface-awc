using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    internal class CreatePlayerByLiveCommandService : ICommandService<CreatePlayerByLiveCommand>
    {
        private readonly IGameApiClient _client;

        public CreatePlayerByLiveCommandService(IGameApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public ValueTask ExecuteAsync(CreatePlayerByLiveCommand command, CancellationToken cancellationToken = default)
            => _client.CreatePlayerAsync(
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
}
