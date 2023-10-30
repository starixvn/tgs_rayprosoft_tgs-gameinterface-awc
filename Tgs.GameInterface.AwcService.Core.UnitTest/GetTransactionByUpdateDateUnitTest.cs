using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using RichardSzalay.MockHttp;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest;

public class GetTransactionByUpdateDateUnitTest
{
    [Fact]
    public async Task No_Transactions_Data()

    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var timeFrom = DateTimeOffset.Now.AddMinutes(-2);

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            transactions = new JsonArray()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getTransactionByUpdateDate")
        .Respond(HttpStatusCode.OK, content: new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var client = new GameRecordApiClient(fakeLog, fakeHttpClient);

        var transactions = await client.GetTransactionByUpdateDateAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            platform: platform,
            timeFrom: timeFrom,
            transactionStatus: TransactionStatus.Settled)
            .ToArrayAsync()
            ?? Enumerable.Empty<GetTransactionByUpdateDateTransaction>();

        Assert.False(transactions.Any());
    }

    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var timeFrom = DateTimeOffset.Now.AddMinutes(-2);

        var response = new JsonObject
        {
            ["status"] = "0000",
            ["transactions"] = new JsonArray
            {
                new JsonObject
                {
                    ["gameType"] =  "SLOT",
                    ["winAmount"] =  0,
                    ["txTime"] =  "2023-10-30T15:10:04+08:00",
                    ["settleStatus"] =  0,
                    ["gameInfo"] =  "{\"freeGameTransactionId\":\"\",\"isAdjustment\":false,\"isEndRound\":true,\"bonusTransactionId\":\"\",\"isBuyFreeSpin\":false,\"isFeature\":false}",
                    ["realWinAmount"] =  0,
                    ["updateTime"] =  "2023-10-30T15:10:04+08:00",
                    ["realBetAmount"] =  3,
                    ["userId"] =  "4ulb1qdzcm1w",
                    ["betType"] =  "1",
                    ["platform"] =  "PG",
                    ["txStatus"] =  1,
                    ["betAmount"] =  3,
                    ["gameName"] =  "Dragon Hatch",
                    ["platformTxId"] =  "1718887979100956672",
                    ["betTime"] =  "2023-10-30T15:10:04+08:00",
                    ["gameCode"] =  "PG-SLOT-042",
                    ["currency"] =  "PHP",
                    ["jackpotWinAmount"] =  0,
                    ["jackpotBetAmount"] =  0,
                    ["turnover"] =  3,
                    ["roundId"] =  "1718887979100956672"
                }
            }
        };

        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getTransactionByUpdateDate")
        .Respond(HttpStatusCode.OK, new StringContent(response.ToJsonString()));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var client = new GameRecordApiClient(fakeLog, fakeHttpClient);

        var transactions = await client.GetTransactionByUpdateDateAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            platform: platform,
            timeFrom: timeFrom)
            .ToArrayAsync()
            ?? Enumerable.Empty<GetTransactionByUpdateDateTransaction>();

        Assert.True(transactions.Any());
        Assert.Equal("1718887979100956672", transactions!.First().PlatformTxId);
        Assert.Equal("1718887979100956672", transactions!.First().RoundId);
        Assert.Equal("SLOT", transactions!.First().GameType);
        Assert.Equal("4ulb1qdzcm1w", transactions!.First().UserId);
        Assert.Equal("PHP", transactions!.First().Currency);
        Assert.Equal("PG-SLOT-042", transactions!.First().GameCode);
        Assert.Equal("Dragon Hatch", transactions!.First().GameName);
        Assert.Equal(1, transactions!.First().TxStatus);
        Assert.Equal(0, transactions!.First().SettleStatus);
        Assert.Equal("2023-10-30T15:10:04+08:00", transactions!.First().BetTime);
        Assert.Equal("2023-10-30T15:10:04+08:00", transactions!.First().TxTime);
        Assert.Equal("2023-10-30T15:10:04+08:00", transactions!.First().UpdateTime);
        Assert.Equal("1", transactions!.First().BetType);
        Assert.Equal(3.0m, transactions!.First().BetAmount);
        Assert.Equal(3.0m, transactions!.First().RealBetAmount);
        Assert.Equal(3.0m, transactions!.First().Turnover);
        Assert.Equal(0.0m, transactions!.First().WinAmount);
        Assert.Equal(0.0m, transactions!.First().RealWinAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotBetAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotWinAmount);
        Assert.Equal(response["transactions"]!.AsArray()!.First()!.ToJsonString(), transactions!.First().AdditionalData);
    }

    [Fact]
    public async Task Normal_ProcessByStatus()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var timeFrom = DateTimeOffset.Now.AddMinutes(-2);

        var response = new JsonObject
        {
            ["status"] = "0000",
            ["transactions"] = new JsonArray
            {
                new JsonObject
                {
                    ["gameType"] =  "SLOT",
                    ["winAmount"] =  0,
                    ["txTime"] =  "2023-10-30T15:10:04+08:00",
                    ["settleStatus"] =  0,
                    ["gameInfo"] =  "{\"freeGameTransactionId\":\"\",\"isAdjustment\":false,\"isEndRound\":true,\"bonusTransactionId\":\"\",\"isBuyFreeSpin\":false,\"isFeature\":false}",
                    ["realWinAmount"] =  0,
                    ["updateTime"] =  "2023-10-30T15:10:04+08:00",
                    ["realBetAmount"] =  3,
                    ["userId"] =  "4ulb1qdzcm1w",
                    ["betType"] =  "1",
                    ["platform"] =  "PG",
                    ["txStatus"] =  1,
                    ["betAmount"] =  3,
                    ["gameName"] =  "Dragon Hatch",
                    ["platformTxId"] =  "1718887979100956672",
                    ["betTime"] =  "2023-10-30T15:10:04+08:00",
                    ["gameCode"] =  "PG-SLOT-042",
                    ["currency"] =  "PHP",
                    ["jackpotWinAmount"] =  0,
                    ["jackpotBetAmount"] =  0,
                    ["turnover"] =  3,
                    ["roundId"] =  "1718887979100956672"
                }
            }
        };

        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getTransactionByUpdateDate")
        .Respond(HttpStatusCode.OK, new StringContent(response.ToJsonString()));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var client = new GameRecordApiClient(fakeLog, fakeHttpClient);

        var transactions = await client.GetTransactionByUpdateDateAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            platform: platform,
            timeFrom: timeFrom,
            transactionStatus: TransactionStatus.Settled)
            .ToArrayAsync()
            ?? Enumerable.Empty<GetTransactionByUpdateDateTransaction>();

        Assert.True(transactions.Any());
        Assert.Equal("1718887979100956672", transactions!.First().PlatformTxId);
        Assert.Equal("1718887979100956672", transactions!.First().RoundId);
        Assert.Equal("SLOT", transactions!.First().GameType);
        Assert.Equal("4ulb1qdzcm1w", transactions!.First().UserId);
        Assert.Equal("PHP", transactions!.First().Currency);
        Assert.Equal("PG-SLOT-042", transactions!.First().GameCode);
        Assert.Equal("Dragon Hatch", transactions!.First().GameName);
        Assert.Equal(1, transactions!.First().TxStatus);
        Assert.Equal(0, transactions!.First().SettleStatus);
        Assert.Equal("2023-10-30T15:10:04+08:00", transactions!.First().BetTime);
        Assert.Equal("2023-10-30T15:10:04+08:00", transactions!.First().TxTime);
        Assert.Equal("2023-10-30T15:10:04+08:00", transactions!.First().UpdateTime);
        Assert.Equal("1", transactions!.First().BetType);
        Assert.Equal(3.0m, transactions!.First().BetAmount);
        Assert.Equal(3.0m, transactions!.First().RealBetAmount);
        Assert.Equal(3.0m, transactions!.First().Turnover);
        Assert.Equal(0.0m, transactions!.First().WinAmount);
        Assert.Equal(0.0m, transactions!.First().RealWinAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotBetAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotWinAmount);
        Assert.Equal(response["transactions"]!.AsArray()!.First()!.ToJsonString(), transactions!.First().AdditionalData);
    }
}
