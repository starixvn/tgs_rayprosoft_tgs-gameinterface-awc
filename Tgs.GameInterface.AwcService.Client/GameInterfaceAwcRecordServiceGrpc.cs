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

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcAeLottoAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcAwsAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcCockfightAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcFacaiAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcFsAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcKmAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcLudoAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcPgsAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcRcbAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcSgAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcSpadeAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcVenusAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
            => await _client.GamePullRecordByAwcYlAsync(new GameInterfaceAwcServiceGamePullRecordeRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcAeLottoAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcAwsAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcCockfightAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcFacaiAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcFsAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcKmAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcLudoAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcPgsAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcRcbAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcSgAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcSpadeAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcVenusAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameSettleByAwcYlAsync(new GameInterfaceAwcServiceGameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUnsettleRecordReply> GameUnsettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
            => await _client.GameUnsettleByAwcAeLottoAsync(new GameInterfaceAwcServiceGameUnsettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUnsettleRecordReply> GameUnsettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset timeFrom, CancellationToken cancellationToken = default)
            => await _client.GameUnsettleByAwcCockfightAsync(new GameInterfaceAwcServiceCockFightGameUnsettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = timeFrom.ToTimestamp(),
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUnsettleRecordReply> GameUnsettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
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
