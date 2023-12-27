using System.Runtime.CompilerServices;
using Tgs.GameInterface.Awc.Protos;

namespace Tgs.GameInterface.Awc.Client;

internal class GameInterfaceAwcClient(
    GameInterfaceAwc.GameInterfaceAwcClient client) : IGameInterfaceAwcClient
{
    public async IAsyncEnumerable<BalanceInfo> AllBalancesAsync(Uri apiUrl, string agentId, string cert, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var request = new AllBalancesRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert
        };

        var reply = await client.AllBalancesAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var items = reply.Items ?? Enumerable.Empty<BalanceInfo>();

        if (!items.Any())
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }

    public async ValueTask<string> CheckingServiceAsync(string machineName, CancellationToken cancellationToken = default)
    {
        var request = new CheckingServiceRequest
        {
            MachineName = machineName,
        };

        var reply = await client
            .CheckingServiceAsync(
                request: request,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return reply.MachineName;
    }

    public async ValueTask<FundReply> FundInAsync(Uri apiUrl, string agentId, string cert, string playerCode, string orderId, decimal amount, CancellationToken cancellationToken = default)
        => await client.FundInAsync(new FundRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            OrderId = orderId,
            Amount = amount,
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<FundReply> FundOutAsync(Uri apiUrl, string agentId, string cert, string playerCode, string orderId, decimal amount, CancellationToken cancellationToken = default)
        => await client.FundOutAsync(new FundRequest()
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            OrderId = orderId,
            Amount = amount,
        }, cancellationToken: cancellationToken).ConfigureAwait(false);

    public async ValueTask<bool> FundStatusAsync(Uri apiUrl, string agentId, string cert, string orderId, CancellationToken cancellationToken = default)
    {
        var request = new FundStatusRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            OrderId = orderId
        };

        var reply = await client
            .FundStatusAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return reply.State;
    }

    public async ValueTask<GameUrlReply> GameUrlByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string betLimit, string language, CancellationToken cancellationToken = default)
    {
        var request = new GameUrlByLiveLobbyRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            IsMobileLogin = isMobileLogin,
            BackUrl = backUrl,
            BetLimit = betLimit,
            Language = language,
        };

        return await client.GameUrlByAwcCockfightAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<GameUrlReply> GameUrlByAwcFsAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default)
    {
        var request = new GameUrlRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            IsMobileLogin = isMobileLogin,
            BackUrl = backUrl,
            ExternalGameId = externalGameId,
            Language = language,
        };

        return await client.GameUrlByAwcFsAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<GameUrlReply> GameUrlByAwcKmAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default)
    {
        var request = new GameUrlRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            IsMobileLogin = isMobileLogin,
            BackUrl = backUrl,
            ExternalGameId = externalGameId,
            Language = language,
        };

        return await client.GameUrlByAwcKmAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<GameUrlReply> GameUrlByAwcLudoAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default)
    {
        var request = new GameUrlRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            IsMobileLogin = isMobileLogin,
            BackUrl = backUrl,
            ExternalGameId = externalGameId,
            Language = language,
        };

        return await client.GameUrlByAwcLudoAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<GameUrlReply> GameUrlByAwcPgsAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default)
    {
        var request = new GameUrlRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            IsMobileLogin = isMobileLogin,
            BackUrl = backUrl,
            ExternalGameId = externalGameId,
            Language = language,
        };

        return await client.GameUrlByAwcPgsAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<GameUrlReply> GameUrlByAwcRcbAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string betLimit, string language, CancellationToken cancellationToken = default)
    {
        var request = new GameUrlByLiveLobbyRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            IsMobileLogin = isMobileLogin,
            BackUrl = backUrl,
            BetLimit = betLimit,
            Language = language,
        };

        return await client.GameUrlByAwcRcbAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<GameUrlReply> GameUrlByAwcSgAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string betLimit, string language, CancellationToken cancellationToken = default)
    {
        var request = new GameUrlByLiveLobbyRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            IsMobileLogin = isMobileLogin,
            BackUrl = backUrl,
            BetLimit = betLimit,
            Language = language,
        };

        return await client.GameUrlByAwcSgAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<GameUrlReply> GameUrlByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default)
    {
        var request = new GameUrlRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            IsMobileLogin = isMobileLogin,
            BackUrl = backUrl,
            ExternalGameId = externalGameId,
            Language = language,
        };

        return await client.GameUrlByAwcSpadeAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<GameUrlReply> GameUrlByAwcVenusAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string betLimit, string language, CancellationToken cancellationToken = default)
    {
        var request = new GameUrlByLiveLobbyRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            IsMobileLogin = isMobileLogin,
            BackUrl = backUrl,
            BetLimit = betLimit,
            Language = language,
        };

        return await client.GameUrlByAwcVenusAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<GameUrlReply> GameUrlByAwcYesbingoAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default)
    {
        var request = new GameUrlRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            IsMobileLogin = isMobileLogin,
            BackUrl = backUrl,
            ExternalGameId = externalGameId,
            Language = language,
        };

        return await client.GameUrlByAwcYesbingoAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<GameUrlReply> GameUrlByAwcYlAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default)
    {
        var request = new GameUrlRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            IsMobileLogin = isMobileLogin,
            BackUrl = backUrl,
            ExternalGameId = externalGameId,
            Language = language,
        };

        return await client.GameUrlByAwcYlAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<PlayerBalanceReply> PlayerBalanceAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default)
    {
        var request = new PlayerBalanceRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode
        };

        return await client.PlayerBalanceAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask PlayerCreateAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string language = "en", CancellationToken cancellationToken = default)
    {
        var request = new PlayerCreateRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            UserName = userName,
            Currency = currency,
            Language = language
        };

        _ = await client.PlayerCreateAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask PlayerCreateByBetLimitAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string betLimit, string language = "en", CancellationToken cancellationToken = default)
    {
        var request = new PlayerCreateByBetLimitRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
            UserName = userName,
            Currency = currency,
            BetLimit = betLimit,
            Language = language
        };

        _ = await client.PlayerCreateByBetLimitAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask PlayerLogoutAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default)
    {
        var request = new PlayerLogoutRequest
        {
            ApiUrl = apiUrl.ToString(),
            AgentId = agentId,
            Cert = cert,
            PlayerCode = playerCode,
        };

        _ = await client.PlayerLogoutAsync(
            request: request,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }
}
