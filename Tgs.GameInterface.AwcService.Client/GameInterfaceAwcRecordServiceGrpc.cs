using Google.Protobuf.WellKnownTypes;
using Tgs.GameInterface.AwcService.Protos;

namespace Tgs.GameInterface.AwcService.Client
{
    internal class GameInterfaceAwcRecordServiceGrpc : IGameInterfaceAwcRecordServiceGrpc
    {
        private readonly GameInterfaceAwcRecordService.GameInterfaceAwcRecordServiceClient _client;

        public GameInterfaceAwcRecordServiceGrpc(GameInterfaceAwcRecordService.GameInterfaceAwcRecordServiceClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcAeLottoAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcAwsAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcCockfightAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcFacaiAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcFsAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcKmAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcLudoAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcPgsAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcRcbAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcSgAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcSpadeAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcVenusAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameSettleTransactionReply> GameSettleByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcYlAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameUnsettleTransactionReply> GameUnsettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameUnsettleByAwcAeLottoAsync(new GameInterfaceAwcServiceGameUnsettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameUnsettleTransactionReply> GameUnsettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset timeFrom, CancellationToken cancellationToken = default)
            => await _client.GameUnsettleByAwcCockfightAsync(new GameInterfaceAwcServiceCockFightGameUnsettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = timeFrom.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameUnsettleTransactionReply> GameUnsettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameUnsettleByAwcRcbAsync(new GameInterfaceAwcServiceGameUnsettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}
