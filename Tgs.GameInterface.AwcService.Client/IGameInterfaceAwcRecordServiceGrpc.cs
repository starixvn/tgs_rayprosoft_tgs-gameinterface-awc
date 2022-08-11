using Tgs.GameInterface.AwcService.Protos;

namespace Tgs.GameInterface.AwcService.Client;

public interface IGameInterfaceAwcRecordServiceGrpc
{
    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGamePullRecordReply> GamePullRecordByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameSettleRecordReply> GameSettleByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameUnsettleRecordReply> GameUnsettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameUnsettleRecordReply> GameUnsettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset timeFrom, CancellationToken cancellationToken = default);

    ValueTask<GameInterfaceAwcServiceGameUnsettleRecordReply> GameUnsettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);
}
