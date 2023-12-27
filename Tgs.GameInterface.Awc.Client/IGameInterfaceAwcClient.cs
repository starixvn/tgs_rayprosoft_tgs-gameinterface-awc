using Tgs.GameInterface.Awc.Protos;

namespace Tgs.GameInterface.Awc.Client;

public interface IGameInterfaceAwcClient
{
    IAsyncEnumerable<BalanceInfo> AllBalancesAsync(Uri apiUrl, string agentId, string cert, CancellationToken cancellationToken = default);

    ValueTask<string> CheckingServiceAsync(string machineName, CancellationToken cancellationToken = default);

    ValueTask<FundReply> FundInAsync(Uri apiUrl, string agentId, string cert, string playerCode, string orderId, decimal amount, CancellationToken cancellationToken = default);

    ValueTask<FundReply> FundOutAsync(Uri apiUrl, string agentId, string cert, string playerCode, string orderId, decimal amount, CancellationToken cancellationToken = default);

    ValueTask<bool> FundStatusAsync(Uri apiUrl, string agentId, string cert, string orderId, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcBgAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string betLimit, string language, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcCockfightAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string betLimit, string language, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcFsAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcKmAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcLudoAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcPgsAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcRcbAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string betLimit, string language, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcSgAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string betLimit, string language, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcSpadeAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcVenusAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string betLimit, string language, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcYesbingoAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default);

    ValueTask<GameUrlReply> GameUrlByAwcYlAsync(Uri apiUrl, string agentId, string cert, string playerCode, bool isMobileLogin, string backUrl, string externalGameId, string language, CancellationToken cancellationToken = default);

    ValueTask<PlayerBalanceReply> PlayerBalanceAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default);

    ValueTask PlayerCreateAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string language = "en", CancellationToken cancellationToken = default);

    ValueTask PlayerCreateByBetLimitAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string betLimit, string language = "en", CancellationToken cancellationToken = default);

    ValueTask PlayerLogoutAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default);
}
