using Tgs.GameInterface.AwcService.Protos;

namespace Tgs.GameInterface.AwcService.Client;

public interface IGameInterfaceAwcServiceClient
{
    ValueTask CreatePlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string language = "en", CancellationToken cancellationToken = default);

    ValueTask CreatePlayerByBetLimitAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string betLimit, string language = "en", CancellationToken cancellationToken = default);

    ValueTask<FundReply> FundInAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default);

    ValueTask<bool> FundOrderCheckingAsync(Uri apiUrl, string agentId, string cert, string transactionId, CancellationToken cancellationToken = default);

    ValueTask<FundReply> FundOutAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcAeLottoAsync(GameUrlRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcAwsAsync(GameUrlRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcFacaiAsync(GameUrlRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcFsAsync(GameUrlRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcKmAsync(GameUrlRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcLudoAsync(GameUrlRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcPgsAsync(GameUrlRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcSpadeAsync(GameUrlRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcYlAsync(GameUrlRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByLiveLobbyByAwcCockfightAsync(GameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlLiveLobbyByAwcRcbAsync(GameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlLiveLobbyByAwcSgAsync(GameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlLiveLobbyByAwcVenusAsync(GameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default);

    ValueTask<BalanceReply> GetBalanceAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default);

    ValueTask<BalancesReply> GetBalancesAsync(Uri apiUrl, string agentId, string cert, CancellationToken cancellationToken = default);

    ValueTask KickPlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default);
}
