using System.Runtime.CompilerServices;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

public record GameRecordUnsettledQueryService : IQueryService<GameRecordUnsettledQuery, GameRecordUnsettledResult>
{
    private readonly IGameRecordApiClient _client;

    public GameRecordUnsettledQueryService(IGameRecordApiClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async IAsyncEnumerable<GameRecordUnsettledResult> QueryAsync(GameRecordUnsettledQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var transactions = await _client.GetOutstandingByBetTimeAsync(
            apiUrl: query.ApiUrl,
            agentId: query.AgentId,
            cert: query.Cert,
            platform: query.Platform,
            startTime: query.StartTime,
            endTime: query.EndTime,
            cancellationToken: cancellationToken)
            .ToArrayAsync(
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        if (!transactions.Any())
        {
            yield break;
        }

        foreach (var transaction in transactions)
        {
            yield return new GameRecordUnsettledResult(
                ExternalRoundId: string.Format("{0}-{1}", query.Platform, transaction.PlatformTxId),
                Platform: query.Platform ?? string.Empty,
                PlatformTxId: transaction.PlatformTxId ?? string.Empty,
                GameType: transaction.GameType ?? string.Empty,
                GameCode: transaction.GameCode ?? string.Empty,
                GameName: transaction.GameName ?? string.Empty,
                RoundId: transaction.RoundId ?? string.Empty,
                UserId: transaction.UserId ?? string.Empty,
                Currency: transaction.Currency ?? string.Empty,
                BetTime: transaction.BetTime ?? string.Empty,
                BetType: transaction.BetType ?? string.Empty,
                BetAmount: transaction.BetAmount,
                RealBetAmount: transaction.RealBetAmount,
                JackpotBetAmount: transaction.JackpotBetAmount,
                GameInfo: transaction.GameInfo ?? string.Empty,
                AdditionalData: transaction.AdditionalData);
        }
    }
}
