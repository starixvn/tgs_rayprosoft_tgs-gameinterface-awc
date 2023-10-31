using Google.Protobuf.WellKnownTypes;
using Tgs.GameInterface.AwcService.Protos;

namespace Tgs.GameInterface.AwcService.Client;

internal class GameInterfaceAwcRecordServiceClient : IGameInterfaceAwcRecordServiceClient
{
    private readonly GameInterfaceAwcRecordService.GameInterfaceAwcRecordServiceClient _client;

    public GameInterfaceAwcRecordServiceClient(GameInterfaceAwcRecordService.GameInterfaceAwcRecordServiceClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcAeLottoAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcAwsAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcCockfightAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcFacaiAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcFsAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcKmAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcLudoAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcPgsAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcRcbAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcSgAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcSpadeAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcVenusAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await _client.GamePullRecordByAwcYlAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcAeLottoAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcAwsAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcCockfightAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcFacaiAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcFsAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcKmAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcLudoAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcPgsAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcRcbAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcSgAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcSpadeAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcVenusAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameSettleByAwcYlAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUnsettleRecordReply> GameUnsettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameUnsettleByAwcAeLottoAsync(new GameUnsettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUnsettleRecordReply> GameUnsettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameUnsettleByAwcCockfightAsync(new GameUnsettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUnsettleRecordReply> GameUnsettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await _client.GameUnsettleByAwcRcbAsync(new GameUnsettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);
}
