using Tgs.GameInterface.AwcService.Protos;

namespace Tgs.GameInterface.AwcService.Client
{
    public interface IGameInterfaceAwcServiceGrpc
    {
        ValueTask CreatePlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string language = "en", CancellationToken cancellationToken = default);

        ValueTask CreatePlayerByBetLimitAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string betLimit, string language = "en", CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceFundReply> FundInAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default);

        ValueTask<bool> FundOrderCheckingAsync(Uri apiUrl, string agentId, string cert, string transactionId, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceFundReply> FundOutAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcAeLottoAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcAwsAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcFacaiAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcFsAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcKmAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcLudoAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcPgsAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcSpadeAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcYlAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByLiveLobbyByAwcCockfightAsync(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlLiveLobbyByAwcRcbAsync(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlLiveLobbyByAwcSgAsync(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlLiveLobbyByAwcVenusAsync(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlLottoLobbyByAwcAeLottoAsync(GameInterfaceAwcServiceGameUrlByLottoLobbyRequest request, CancellationToken cancellationToken = default);

        ValueTask<GameInterfaceAwcServiceBalanceReply> GetBalanceAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default);

        ValueTask KickPlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default);
    }
}
