using Tgs.GameInterface.Awc.Core.Models;

namespace Tgs.GameInterface.Awc.Core;

public interface IGameApiClient
{
    /// <summary>
    /// Funds the order checking asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="transactionId">The transaction identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    ValueTask<bool> CheckTransferOperationAsync(Uri apiUrl, string agentId, string cert, string transactionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates the player asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="playerCode">The player code.</param>
    /// <param name="userName">Name of the user.</param>
    /// <param name="currency">The currency.</param>
    /// <param name="language">The language.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    ValueTask CreatePlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string language = "en", CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates the player asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="playerCode">The player code.</param>
    /// <param name="userName">Name of the user.</param>
    /// <param name="currency">The currency.</param>
    /// <param name="betLimit">The bet limit.</param>
    /// <param name="language">The language.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    ValueTask CreatePlayerAsync(Uri apiUrl, string agentId, string cert, string playerCode, string userName, string currency, string betLimit, string language = "en", CancellationToken cancellationToken = default);

    /// <summary>
    /// Funds the out asynchronous.(Tgs -> Gp)
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="playerCode">The player code.</param>
    /// <param name="transactionId">The transaction identifier.</param>
    /// <param name="amount">The amount.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    ValueTask<FundResp> DepositAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all balances asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    IAsyncEnumerable<BalanceInfo> GetAllBalancesAsync(Uri apiUrl, string agentId, string cert, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the balance asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="playerCode">The player code.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    ValueTask<GetBalanceResp> GetBalanceAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default);

    /// <summary>
    /// Logins the and launch game asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="data">The data.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    ValueTask<LoginAndLaunchGameResult> LoginAndLaunchGameAsync(Uri apiUrl, string agentId, string cert, LoginAndLaunchGame data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Logins the and launch game asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="data">The data.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    ValueTask<LoginAndLaunchGameResult> LoginAndLaunchGameAsync(Uri apiUrl, string agentId, string cert, LoginAndLaunchGameByLive data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Logouts the asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="playerCode">The player code.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    ValueTask LogoutAsync(Uri apiUrl, string agentId, string cert, string playerCode, CancellationToken cancellationToken = default);

    /// <summary>
    /// Funds the in asynchronous.(GP -> Tgs)
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="playerCode">The player code.</param>
    /// <param name="transactionId">The transaction identifier.</param>
    /// <param name="amount">The amount.</param>
    /// <param name="withdrawType">Type of the withdraw.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    ValueTask<FundResp> WithdrawAsync(Uri apiUrl, string agentId, string cert, string playerCode, string transactionId, decimal amount, int withdrawType = 0, CancellationToken cancellationToken = default);
}
