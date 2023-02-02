using Tgs.GameInterface.AwcService.Protos;

namespace Tgs.GameInterface.AwcService.Client;

internal class GameInterfaceAwcServiceClient : IGameInterfaceAwcServiceClient
{
    private readonly GameInterfaceAwcService.GameInterfaceAwcServiceClient _client;

    public GameInterfaceAwcServiceClient(GameInterfaceAwcService.GameInterfaceAwcServiceClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask CreatePlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string language = "en", CancellationToken cancellationToken = default)
    {
        _ = await _client.CreatePlayerAsync(new CreatePlayerRequest()
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
        _ = await _client.CreatePlayerByBetLimitAsync(new CreatePlayerByBetLimitRequest()
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

    public async ValueTask<FundReply> FundInAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default)
        => await _client.FundInAsync(new FundRequest()
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
        var reply = await _client.FundOrderCheckingAsync(new FundOrderCheckingRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            TransactionId = transactionId
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

        return reply.Exist;
    }

    public async ValueTask<FundReply> FundOutAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default)
        => await _client.FundOutAsync(new FundRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            TransactionId = transactionId,
            Amount = amount,
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlByAwcAeLottoAsync(GameUrlRequest request, CancellationToken cancellationToken = default)
        => await _client.GameUrlByAwcAeLottoAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlByAwcAwsAsync(GameUrlRequest request, CancellationToken cancellationToken = default)
         => await _client.GameUrlByAwcAwsAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlByAwcFacaiAsync(GameUrlRequest request, CancellationToken cancellationToken = default)
        => await _client.GameUrlByAwcFacaiAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlByAwcFsAsync(GameUrlRequest request, CancellationToken cancellationToken = default)
        => await _client.GameUrlByAwcFsAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlByAwcKmAsync(GameUrlRequest request, CancellationToken cancellationToken = default)
        => await _client.GameUrlByAwcKmAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlByAwcLudoAsync(GameUrlRequest request, CancellationToken cancellationToken = default)
        => await _client.GameUrlByAwcLudoAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlByAwcPgsAsync(GameUrlRequest request, CancellationToken cancellationToken = default)
         => await _client.GameUrlByAwcPgsAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlByAwcSpadeAsync(GameUrlRequest request, CancellationToken cancellationToken = default)
        => await _client.GameUrlByAwcSpadeAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlByAwcYlAsync(GameUrlRequest request, CancellationToken cancellationToken = default)
        => await _client.GameUrlByAwcYlAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlByLiveLobbyByAwcCockfightAsync(GameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default)
        => await _client.GameUrlByLiveLobbyByAwcCockfightAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlLiveLobbyByAwcRcbAsync(GameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default)
        => await _client.GameUrlLiveLobbyByAwcRcbAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlLiveLobbyByAwcSgAsync(GameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default)
         => await _client.GameUrlLiveLobbyByAwcSgAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<GameUrlReply> GameUrlLiveLobbyByAwcVenusAsync(GameUrlByLiveLobbyRequest request, CancellationToken cancellationToken = default)
        => await _client.GameUrlLiveLobbyByAwcVenusAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<BalanceReply> GetBalanceAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default)
        => await _client.GetBalanceAsync(new BalanceRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<BalancesReply> GetBalancesAsync(Uri apiUrl, string agentId, string cert, CancellationToken cancellationToken = default)
        => await _client
        .GetBalancesAsync(
            new BalancesRequest
            {
                ApiUrl = apiUrl.ToString(),
                AgentId = agentId,
                Cert = cert
            },
          cancellationToken: cancellationToken)
        .ConfigureAwait(false);


    public async ValueTask KickPlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default)
    {
        _ = await _client.KickPlayerAsync(new KickPlayerRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
        }, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}
