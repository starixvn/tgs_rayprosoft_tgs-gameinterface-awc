using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    internal class TransactionByUpdateDateByStatusGetService : IQueryService<TransactionByUpdateDateByStatusQuery, TransactionByUpdateDateResult>
    {
        private readonly IGameRecordApiClient _client;
        private readonly ILogger<TransactionByUpdateDateByStatusGetService> _logger;

        public TransactionByUpdateDateByStatusGetService(
            ILogger<TransactionByUpdateDateByStatusGetService> logger,
            IGameRecordApiClient client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async IAsyncEnumerable<TransactionByUpdateDateResult> QueryAsync(TransactionByUpdateDateByStatusQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var result = await _client.GetTransactionByUpdateDateAsync(
                apiUrl: query.ApiUrl,
                agentId: query.AgentId,
                cert: query.Cert,
                platform: query.Platform,
                timeFrom: query.TimeFrom,
                transactionStatus: query.TransactionStatus,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            if (!result.Success)
            {
                _logger.LogError("Logon:{logon} | Message:{message}", DateTime.UtcNow.ToString("O"), result.Message ?? string.Empty);
                yield break;
            }

            if (result.Transactions is null || !result.Transactions.Any())
            {
                yield break;
            }

            foreach (var transaction in result.Transactions)
            {
                yield return new TransactionByUpdateDateResult(
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
                    GameInfo: transaction.GameInfo ?? string.Empty);
            }
        }
    }
}
