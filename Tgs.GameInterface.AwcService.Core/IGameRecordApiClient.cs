using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core;

public interface IGameRecordApiClient
{
    /// <summary>
    /// Gets the outstanding by bet time asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="platform">The platform.</param>
    /// <param name="startTime">The start time.</param>
    /// <param name="endTime">The end time.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    IAsyncEnumerable<GetOutstandingByBetTimeTransaction> GetOutstandingByBetTimeAsync(Uri apiUrl, string agentId, string cert, string platform, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the transaction by tx time asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="platform">The platform.</param>
    /// <param name="startTime">The start time.</param>
    /// <param name="endTime">The end time.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    IAsyncEnumerable<GetTransactionByTxTimeTransaction> GetTransactionByTxTimeAsync(Uri apiUrl, string agentId, string cert, string platform, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the transaction by update date asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="platform">The platform.</param>
    /// <param name="timeFrom">The time from.</param>
    /// <param name="transactionStatus">The transaction status.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    IAsyncEnumerable<GetTransactionByUpdateDateTransaction> GetTransactionByUpdateDateAsync(Uri apiUrl, string agentId, string cert, string platform, DateTimeOffset timeFrom, TransactionStatus transactionStatus, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the transaction by update date asynchronous.
    /// </summary>
    /// <param name="apiUrl">The API URL.</param>
    /// <param name="agentId">The agent identifier.</param>
    /// <param name="cert">The cert.</param>
    /// <param name="platform">The platform.</param>
    /// <param name="timeFrom">The time from.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    IAsyncEnumerable<GetTransactionByUpdateDateTransaction> GetTransactionByUpdateDateAsync(Uri apiUrl, string agentId, string cert, string platform, DateTimeOffset timeFrom, CancellationToken cancellationToken = default);
}
