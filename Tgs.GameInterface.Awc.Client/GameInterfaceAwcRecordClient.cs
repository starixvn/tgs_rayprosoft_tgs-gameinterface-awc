using System.Runtime.CompilerServices;
using Google.Protobuf.WellKnownTypes;
using Tgs.GameInterface.Awc.Protos;

namespace Tgs.GameInterface.Awc.Client;

internal class GameInterfaceAwcRecordClient(
    GameInterfaceAwcRecord.GameInterfaceAwcRecordClient client) : IGameInterfaceAwcRecordClient
{
    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcAeLottoAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcAwsAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcBgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcBgAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcCockfightAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcFacaiAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcFsAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcKmAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcLudoAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcPgsAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcRcbAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcSgAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcSpadeAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcVenusAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcYesbingoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcYesbingoAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GamePullRecordByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset time_from, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GamePullRecordByAwcYlAsync(
            new GamePullRecordeRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TimeFrom = time_from.ToTimestamp()
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcAeLottoAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcAwsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcAwsAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcBgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcBgAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcCockfightAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcFacaiAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcFacaiAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcFsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcFsAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcKmAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcKmAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcLudoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcLudoAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcPgsAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcPgsAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcRcbAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcSgAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcSgAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcSpadeAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcVenusAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcVenusAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcYesbingoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcYesbingoAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameSettleByAwcYlAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameSettleByAwcYlAsync(
            new GameSettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameUnsettleByAwcAeLottoAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameUnsettleByAwcAeLottoAsync(
            new GameUnsettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameUnsettleByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameUnsettleByAwcCockfightAsync(
            new GameUnsettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<GameWagerInfo> GameUnsettleByAwcRcbAsync(Uri apiUrl, string agentId, string cert, DateTimeOffset startTime, DateTimeOffset endTime, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var reply = await client.GameUnsettleByAwcRcbAsync(
            new GameUnsettleRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                StartTime = startTime.ToTimestamp(),
                EndTime = endTime.ToTimestamp(),
            },
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<GameWagerInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }
}
