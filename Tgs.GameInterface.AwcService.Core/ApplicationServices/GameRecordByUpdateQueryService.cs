using System.Runtime.CompilerServices;
using Tgs.GameInterface.AwcService.Core.Models;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices;

internal class GameRecordByUpdateQueryService : IQueryService<GameRecordByUpdateQuery, GameRecordResult>
{
    private readonly IGameRecordApiClient _client;

    public GameRecordByUpdateQueryService(IGameRecordApiClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async IAsyncEnumerable<GameRecordResult> QueryAsync(GameRecordByUpdateQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var transactions = await _client.GetTransactionByUpdateDateAsync(
            apiUrl: query.ApiUrl,
            agentId: query.AgentId,
            cert: query.Cert,
            platform: query.Platform,
            timeFrom: query.TimeFrom,
            cancellationToken: cancellationToken)
            .ToArrayAsync(
            cancellationToken: cancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GetTransactionByUpdateDateTransaction>();

        if (!transactions.Any())
        {
            yield break;
        }

        foreach (var transaction in transactions)
        {
            yield return new GameRecordResult(
                ExternalRoundId: string.Format("{0}-{1}", query.Platform, transaction.PlatformTxId),
                Platform: query.Platform ?? string.Empty,
                PlatformTxId: transaction.PlatformTxId ?? string.Empty,
                GameType: transaction.GameType ?? string.Empty,
                GameCode: transaction.GameCode ?? string.Empty,
                GameName: transaction.GameName ?? string.Empty,
                RoundId: transaction.RoundId ?? string.Empty,
                UserId: transaction.UserId ?? string.Empty,
                Currency: transaction.Currency ?? string.Empty,
                TxStatus: transaction.TxStatus,
                SettleStatus: transaction.SettleStatus,
                BetTime: transaction.BetTime ?? string.Empty,
                TxTime: transaction.TxTime ?? string.Empty,
                UpdateTime: transaction.UpdateTime ?? string.Empty,
                BetType: transaction.BetType ?? string.Empty,
                BetAmount: transaction.BetAmount,
                RealBetAmount: transaction.RealBetAmount,
                Turnover: transaction.Turnover,
                WinAmount: transaction.WinAmount,
                RealWinAmount: transaction.RealWinAmount,
                JackpotBetAmount: transaction.JackpotBetAmount,
                JackpotWinAmount: transaction.JackpotWinAmount,
                GameInfo: transaction.GameInfo ?? string.Empty,
                AdditionalData: transaction.AdditionalData ?? string.Empty);
        }
    }
}
