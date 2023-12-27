using Tgs.GameInterface.Awc.Protos;

namespace Tgs.GameInterface.Awc.Client;

public interface IGameInterfaceAwcRecordClient
{
    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcBgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcYesbingoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcBgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcYesbingoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameSettleByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameUnsettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameUnsettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    IAsyncEnumerable<GameWagerInfo> GameUnsettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);
}
