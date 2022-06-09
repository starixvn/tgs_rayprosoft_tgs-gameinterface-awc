using Tgs.GameInterface.AwcService.Protos;

namespace Tgs.GameInterface.AwcService.Client
{
    internal class GameInterfaceAwcServiceGrpc : IGameInterfaceAwcServiceGrpc
    {
        private readonly GameInterfaceAwcService.GameInterfaceAwcServiceClient _client;

        public GameInterfaceAwcServiceGrpc(GameInterfaceAwcService.GameInterfaceAwcServiceClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async ValueTask CreatePlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string language = "en", CancellationToken cancellationToken = default)
        {
            _ = await _client.CreatePlayerAsync(new GameInterfaceAwcServiceCreatePlayerRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                PlayerCode = playerCode,
                UserName = userName,
                Currency = currency,
                Language = language
            }, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask CreatePlayerByBetLimitAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string betLimit, string language = "en", CancellationToken cancellationToken = default)
        {
            _ = await _client.CreatePlayerByBetLimitAsync(new GameInterfaceAwcServiceCreatePlayerByBetLimitRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                PlayerCode = playerCode,
                UserName = userName,
                Currency = currency,
                BetLimit = betLimit,
                Language = language
            }, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<GameInterfaceAwcServiceFundReply> FundInAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default)
            => await _client.FundInAsync(new GameInterfaceAwcServiceFundRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                PlayerCode = playerCode,
                TransactionId = transactionId,
                Amount = amount,
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<bool> FundOrderCheckingAsync(Uri apiUrl, string agentId, string cert, string transactionId, CancellationToken cancellationToken = default)
        {
            var reply = await _client.FundOrderCheckingAsync(new GameInterfaceAwcServiceFundOrderCheckingRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                TransactionId = transactionId
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

            return reply.Exist;
        }

        public async ValueTask<GameInterfaceAwcServiceFundReply> FundOutAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default)
            => await _client.FundOutAsync(new GameInterfaceAwcServiceFundRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                PlayerCode = playerCode,
                TransactionId = transactionId,
                Amount = amount,
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcAeLottoAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default)
            => await _client.GameUrlByAwcAeLottoAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcAwsAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default)
             => await _client.GameUrlByAwcAwsAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcFacaiAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default)
            => await _client.GameUrlByAwcFacaiAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcFsAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default)
            => await _client.GameUrlByAwcFsAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcKmAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default)
            => await _client.GameUrlByAwcKmAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcLudoAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default)
            => await _client.GameUrlByAwcLudoAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcPgsAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default)
             => await _client.GameUrlByAwcPgsAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcSpadeAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default)
            => await _client.GameUrlByAwcSpadeAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByAwcYlAsync(GameInterfaceAwcServiceGameUrlRequest request, CancellationToken cancellationToken = default)
            => await _client.GameUrlByAwcYlAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByLiveLobbyByAwcCockfightAsync(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default)
            => await _client.GameUrlByLiveLobbyByAwcCockfightAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByLiveLobbyByAwcRcbAsync(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default)
            => await _client.GameUrlByLiveLobbyByAwcRcbAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByLiveLobbyByAwcVenusAsync(GameInterfaceAwcServiceGameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default)
            => await _client.GameUrlByLiveLobbyByAwcVenusAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceGameUrlReply> GameUrlByLottoLobbyByAwcAeLottoAsync(GameInterfaceAwcServiceGameUrlByLottoLobbyRequest request, CancellationToken cancellationToken = default)
            => await _client.GameUrlByLottoLobbyByAwcAeLottoAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask<GameInterfaceAwcServiceBalanceReply> GetBalanceAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default)
            => await _client.GetBalanceAsync(new GameInterfaceAwcServiceBalanceRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                PlayerCode = playerCode,
            }, cancellationToken: cancellationToken).ConfigureAwait(false);

        public async ValueTask KickPlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default)
        {
            _ = await _client.KickPlayerAsync(new GameInterfaceAwcServiceKickPlayerRequest()
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert,
                PlayerCode = playerCode,
            }, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
