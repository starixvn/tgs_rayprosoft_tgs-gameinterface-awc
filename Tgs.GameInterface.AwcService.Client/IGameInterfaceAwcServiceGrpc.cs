using Tgs.GameInterface.AwcService.Protos;

namespace Tgs.GameInterface.AwcService.Client
{
    public interface IGameInterfaceAwcServiceGrpc
    {
        public ValueTask CreatePlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string language = "en", CancellationToken cancellationToken = default);

        public ValueTask CreatePlayerByBetLimitAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string betLimit, string language = "en", CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceFundReply> FundInAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceFundReply> FundOutAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcAeLottoAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcAwsAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcFacaiAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcFsAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcKmAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcLudoAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcPgsAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcSpadeAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcYlAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByLiveLobbyByAwcCockfightAsync(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByLiveLobbyByAwcRcbAsync(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByLiveLobbyByAwcVenusAsync(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByLottoLobbyByAwcAeLottoAsync(GameInterfaceAwcServiceGameUrlByLottoLobbyRequest request, CancellationToken cancellationToken = default);

        public ValueTask<GameInterfaceAwcServiceBalanceReply> GetBalanceAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default);

        public ValueTask KickPlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default);
    }
}
