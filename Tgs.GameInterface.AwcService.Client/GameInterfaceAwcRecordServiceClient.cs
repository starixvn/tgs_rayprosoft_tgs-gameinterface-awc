using Google.Protobuf.WellKnownTypes;
using Tgs.GameInterface.AwcService.Protos;

namespace Tgs.GameInterface.AwcService.Client;

internal class GameInterfaceAwcRecordServiceClient(
    GameInterfaceAwcRecordService.GameInterfaceAwcRecordServiceClient client) : IGameInterfaceAwcRecordServiceClient
{
    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcAeLottoAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcAwsAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcCockfightAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcFacaiAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcFsAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcKmAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcLudoAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcPgsAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcRcbAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcSgAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcSpadeAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcVenusAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcYesbingoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcYesbingoAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GamePullRecordReply> GamePullRecordByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default)
        => await client.GamePullRecordByAwcYlAsync(new GamePullRecordeRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TimeFrom = time_from.ToTimestamp()
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcAeLottoAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcAwsAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcCockfightAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcFacaiAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcFsAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcKmAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcLudoAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcPgsAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcRcbAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcSgAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcSpadeAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcVenusAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcYesbingoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcYesbingoAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameSettleRecordReply> GameSettleByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameSettleByAwcYlAsync(new GameSettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUnsettleRecordReply> GameUnsettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameUnsettleByAwcAeLottoAsync(new GameUnsettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUnsettleRecordReply> GameUnsettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameUnsettleByAwcCockfightAsync(new GameUnsettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUnsettleRecordReply> GameUnsettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        => await client.GameUnsettleByAwcRcbAsync(new GameUnsettleRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            StartTime = startTime.ToTimestamp(),
            EndTime = endTime.ToTimestamp(),
        }, cancellationToken: cancellationToken).ConfigureAwait(false);
}
