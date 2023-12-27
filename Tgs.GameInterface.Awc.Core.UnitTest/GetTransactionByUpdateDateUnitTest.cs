using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using RichardSzalay.MockHttp;
using Tgs.GameInterface.Awc.Core;
using Tgs.GameInterface.Awc.Core.Models;

namespace Tgs.GameInterface.Awc.Core.UnitTest;

public class GetTransactionByUpdateDateUnitTest
{
    [Fact]
    public async Task FASTSPIN_Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "FASTSPIN";
        var timeFrom = DateTimeOffset.Now.AddMinutes(-2);

        var response = new JsonObject
        {
            ["status"] = "0000",
            ["transactions"] = new JsonArray
            {
                new JsonObject
                {
                    ["gameType"] = "SLOT",
                    ["winAmount"] = 0.6,
                    ["txTime"] = "2023-10-30T15:36:08Z",
                    ["settleStatus"] = 0,
                    ["gameInfo"] = "{\"refTicketIds\":[\"10527379604\",\"10527379605\"],\"isEndRound\":true,\"isBuyFreeSpin\":false}",
                    ["realWinAmount"] = 0.6,
                    ["updateTime"] = "2023-10-30T15:36:08Z",
                    ["realBetAmount"] = 2,
                    ["userId"] = "4uiwpyw4pvqu",
                    ["platform"] = "FASTSPIN",
                    ["txStatus"] = 1,
                    ["betAmount"] = 2,
                    ["gameName"] = "The Nutcrackers",
                    ["platformTxId"] = "20231030233608139281864",
                    ["betTime"] = "2023-10-30T15:36:08Z",
                    ["gameCode"] = "FastSpin-SLOT-030",
                    ["currency"] = "PHP",
                    ["jackpotWinAmount"]= 0,
                    ["jackpotBetAmount"]= 0,
                    ["turnover"]= 2,
                    ["roundId"] = "20231030233608105281801"
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
        Assert.Equal("20231030233608139281864", transactions!.First().PlatformTxId);
        Assert.Equal("20231030233608105281801", transactions!.First().RoundId);
        Assert.Equal("SLOT", transactions!.First().GameType);
        Assert.Equal("4uiwpyw4pvqu", transactions!.First().UserId);
        Assert.Equal("PHP", transactions!.First().Currency);
        Assert.Equal("FastSpin-SLOT-030", transactions!.First().GameCode);
        Assert.Equal("The Nutcrackers", transactions!.First().GameName);
        Assert.Equal(1, transactions!.First().TxStatus);
        Assert.Equal(0, transactions!.First().SettleStatus);
        Assert.Equal("2023-10-30T15:36:08Z", transactions!.First().BetTime);
        Assert.Equal("2023-10-30T15:36:08Z", transactions!.First().TxTime);
        Assert.Equal("2023-10-30T15:36:08Z", transactions!.First().UpdateTime);
        Assert.Equal(string.Empty, transactions!.First().BetType);
        Assert.Equal(2.0m, transactions!.First().BetAmount);
        Assert.Equal(2.0m, transactions!.First().RealBetAmount);
        Assert.Equal(2.0m, transactions!.First().Turnover);
        Assert.Equal(0.6m, transactions!.First().WinAmount);
        Assert.Equal(0.6m, transactions!.First().RealWinAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotBetAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotWinAmount);
        Assert.Equal(response["transactions"]!.AsArray()!.FirstOrDefault()!.ToJsonString(), transactions!.First().AdditionalData);
    }

    [Fact]
    public async Task KINGMAKER_Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "KINGMAKER";
        var timeFrom = DateTimeOffset.Now.AddMinutes(-2);

        var response = new JsonObject
        {
            ["status"] = "0000",
            ["transactions"] = new JsonArray
            {
                new JsonObject
                {
                    ["gameType"] = "TABLE",
                    ["winAmount"] = 40,
                    ["txTime"] = "2023-10-30T10:17:04Z",
                    ["settleStatus"] = 0,
                    ["gameInfo"] = "{\"extension1\":\"pk3\",\"betType\":\"br-player : 20.0\",\"reason\":\"payout\",\"agentId\":\"pk3\",\"link\":\"https://supports2.bo.p7.ns86.kingdomhall729.com/plays/br-T2JAFei0/by_reference_number?transId=653f829997235a003eb5bd68\",\"commission\":0.0,\"profit\":20.0}",
                    ["realWinAmount"] = 40,
                    ["updateTime"] = "2023-10-30T10:17:04Z",
                    ["realBetAmount"] = 20,
                    ["userId"] = "4ugu9l53wpy7",
                    ["platform"] = "KINGMAKER",
                    ["txStatus"] = 1,
                    ["betAmount"] = 20,
                    ["gameName"] = "baccarat",
                    ["platformTxId"] = "653f829997235a003eb5bd68",
                    ["betTime"] = "2023-10-30T10:16:50Z",
                    ["gameCode"] = "KM-TABLE-026",
                    ["currency"] = "PHP",
                    ["jackpotWinAmount"] = 0,
                    ["jackpotBetAmount"] = 0,
                    ["turnover"] = 20,
                    ["roundId"] = "br-T2JAFei0"
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
        Assert.Equal("653f829997235a003eb5bd68", transactions!.First().PlatformTxId);
        Assert.Equal("br-T2JAFei0", transactions!.First().RoundId);
        Assert.Equal("TABLE", transactions!.First().GameType);
        Assert.Equal("4ugu9l53wpy7", transactions!.First().UserId);
        Assert.Equal("PHP", transactions!.First().Currency);
        Assert.Equal("KM-TABLE-026", transactions!.First().GameCode);
        Assert.Equal("baccarat", transactions!.First().GameName);
        Assert.Equal(1, transactions!.First().TxStatus);
        Assert.Equal(0, transactions!.First().SettleStatus);
        Assert.Equal("2023-10-30T10:16:50Z", transactions!.First().BetTime);
        Assert.Equal("2023-10-30T10:17:04Z", transactions!.First().TxTime);
        Assert.Equal("2023-10-30T10:17:04Z", transactions!.First().UpdateTime);
        Assert.Equal(string.Empty, transactions!.First().BetType);
        Assert.Equal(20.0m, transactions!.First().BetAmount);
        Assert.Equal(20.0m, transactions!.First().RealBetAmount);
        Assert.Equal(20.0m, transactions!.First().Turnover);
        Assert.Equal(40.0m, transactions!.First().WinAmount);
        Assert.Equal(40.0m, transactions!.First().RealWinAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotBetAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotWinAmount);
        Assert.Equal(response["transactions"]!.AsArray()!.FirstOrDefault()!.ToJsonString(), transactions!.First().AdditionalData);
    }

    [Fact]
    public async Task No_Transactions_Data()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var timeFrom = DateTimeOffset.Now.AddMinutes(-2);

        var response = new JsonObject
        {
            ["status"] = "0000",
            ["transactions"] = new JsonArray { }
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

        Assert.False(transactions.Any());
    }

    [Fact]
    public async Task PG_Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "PG";
        var timeFrom = DateTimeOffset.Now.AddMinutes(-2);

        var response = new JsonObject
        {
            ["status"] = "0000",
            ["transactions"] = new JsonArray
            {
                new JsonObject
                {
                    ["gameType"] = "SLOT",
                    ["winAmount"] = 0.6,
                    ["txTime"] = "2023-10-30T15:59:09Z",
                    ["settleStatus"] = 0,
                    ["gameInfo"] = "{\"freeGameTransactionId\":\"\",\"isAdjustment\":false,\"isEndRound\":false,\"bonusTransactionId\":\"\",\"isBuyFreeSpin\":false,\"isFeature\":false}",
                    ["realWinAmount"] = 0.6,
                    ["updateTime"] = "2023-10-30T15:59:10Z",
                    ["realBetAmount"] = 3,
                    ["userId"] = "4ul9yrhwocnx",
                    ["betType"] = "1",
                    ["platform"] = "PG",
                    ["txStatus"] = 1,
                    ["betAmount"] = 3,
                    ["gameName"] = "Bakery Bonanza",
                    ["platformTxId"] = "1719021130368418304",
                    ["betTime"] = "2023-10-30T15:59:09Z",
                    ["gameCode"] = "PG-SLOT-115",
                    ["currency"] = "PHP",
                    ["jackpotWinAmount"] = 0,
                    ["jackpotBetAmount"] = 0,
                    ["turnover"] = 3,
                    ["roundId"] = "1719021130368418304"
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
        Assert.Equal("1719021130368418304", transactions!.First().PlatformTxId);
        Assert.Equal("1719021130368418304", transactions!.First().RoundId);
        Assert.Equal("SLOT", transactions!.First().GameType);
        Assert.Equal("4ul9yrhwocnx", transactions!.First().UserId);
        Assert.Equal("PHP", transactions!.First().Currency);
        Assert.Equal("PG-SLOT-115", transactions!.First().GameCode);
        Assert.Equal("Bakery Bonanza", transactions!.First().GameName);
        Assert.Equal(1, transactions!.First().TxStatus);
        Assert.Equal(0, transactions!.First().SettleStatus);
        Assert.Equal("2023-10-30T15:59:09Z", transactions!.First().BetTime);
        Assert.Equal("2023-10-30T15:59:09Z", transactions!.First().TxTime);
        Assert.Equal("2023-10-30T15:59:10Z", transactions!.First().UpdateTime);
        Assert.Equal("1", transactions!.First().BetType);
        Assert.Equal(3.0m, transactions!.First().BetAmount);
        Assert.Equal(3.0m, transactions!.First().RealBetAmount);
        Assert.Equal(3.0m, transactions!.First().Turnover);
        Assert.Equal(0.6m, transactions!.First().WinAmount);
        Assert.Equal(0.6m, transactions!.First().RealWinAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotBetAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotWinAmount);
        Assert.Equal(response["transactions"]!.AsArray()!.FirstOrDefault()!.ToJsonString(), transactions!.First().AdditionalData);
    }

    [Fact]
    public async Task SEXYBCRT_Normal_Process()
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
                    ["gameType"] = "LIVE",
                    ["winAmount"] = 45,
                    ["txTime"] = "2023-10-30T15:09:34Z",
                    ["settleStatus"] = 0,
                    ["gameInfo"] = "{\"result\":[\"2,3,3\"],\"roundStartTime\":\"10/30/2023 23:09:16.480\",\"winner\":\"2,3,3\",\"ip\":\"119.246.233.199\",\"odds\":8.0,\"tableId\":131,\"dealerDomain\":\"Mexico\",\"winLoss\":40.0,\"status\":\"WIN\"}",
                    ["realWinAmount"] = 45,
                    ["updateTime"] = "2023-10-30T15:10:16Z",
                    ["realBetAmount"] = 5,
                    ["userId"] = "4ujkd378gxzy",
                    ["betType"] = "Double 3",
                    ["platform"] = "SEXYBCRT",
                    ["txStatus"] = 1,
                    ["betAmount"] = 5,
                    ["gameName"] = "Extra Sicbo",
                    ["platformTxId"] = "ESIC-1229831096",
                    ["betTime"] = "2023-10-30T15:09:34Z",
                    ["gameCode"] = "MX-LIVE-016",
                    ["currency"] = "HKD",
                    ["jackpotWinAmount"] = 0,
                    ["jackpotBetAmount"] = 0,
                    ["turnover"] = 5,
                    ["roundId"] = "Mexico-131-GA249260031"
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
        Assert.Equal("ESIC-1229831096", transactions!.First().PlatformTxId);
        Assert.Equal("Mexico-131-GA249260031", transactions!.First().RoundId);
        Assert.Equal("LIVE", transactions!.First().GameType);
        Assert.Equal("4ujkd378gxzy", transactions!.First().UserId);
        Assert.Equal("HKD", transactions!.First().Currency);
        Assert.Equal("MX-LIVE-016", transactions!.First().GameCode);
        Assert.Equal("Extra Sicbo", transactions!.First().GameName);
        Assert.Equal(1, transactions!.First().TxStatus);
        Assert.Equal(0, transactions!.First().SettleStatus);
        Assert.Equal("2023-10-30T15:09:34Z", transactions!.First().BetTime);
        Assert.Equal("2023-10-30T15:09:34Z", transactions!.First().TxTime);
        Assert.Equal("2023-10-30T15:10:16Z", transactions!.First().UpdateTime);
        Assert.Equal("Double 3", transactions!.First().BetType);
        Assert.Equal(5.0m, transactions!.First().BetAmount);
        Assert.Equal(5.0m, transactions!.First().RealBetAmount);
        Assert.Equal(5.0m, transactions!.First().Turnover);
        Assert.Equal(45.0m, transactions!.First().WinAmount);
        Assert.Equal(45.0m, transactions!.First().RealWinAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotBetAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotWinAmount);
        Assert.Equal(response["transactions"]!.AsArray()!.FirstOrDefault()!.ToJsonString(), transactions!.First().AdditionalData);
    }

    [Fact]
    public async Task VENUS_Normal_Process()
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
                    ["gameType"] = "LIVE",
                    ["winAmount"] = 975,
                    ["txTime"] = "2023-10-30T10:21:12Z",
                    ["settleStatus"] = 0,
                    ["gameInfo"] = "{\"result\":[\"S09\",\"S09\",\"\",\"H10\",\"H09\",\"\"],\"roundStartTime\":\"10/30/2023 18:21:02.833\",\"winner\":\"BANKER\",\"ip\":\"49.145.131.133\",\"odds\":0.95,\"streamerId\":\"\",\"tableId\":6,\"dealerDomain\":\"Bavet\",\"winLoss\":475.0,\"status\":\"WIN\"}",
                    ["realWinAmount"] = 975,
                    ["updateTime"] = "2023-10-30T10:21:53Z",
                    ["realBetAmount"] = 500,
                    ["userId"] = "4uh0vqwbharj",
                    ["betType"] = "Banker",
                    ["platform"] = "VENUS",
                    ["txStatus"] = 1,
                    ["betAmount"] = 500,
                    ["gameName"] = "Baccarat Classic",
                    ["platformTxId"] = "BAC-8720563426",
                    ["betTime"] = "2023-10-30T10:21:12Z",
                    ["gameCode"] = "VN-LIVE-001",
                    ["currency"] = "PHP",
                    ["jackpotWinAmount"] = 0,
                    ["jackpotBetAmount"] = 0,
                    ["turnover"] = 500,
                    ["roundId"] = "Bavet-06-GA395180036"
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
        Assert.Equal("BAC-8720563426", transactions!.First().PlatformTxId);
        Assert.Equal("Bavet-06-GA395180036", transactions!.First().RoundId);
        Assert.Equal("LIVE", transactions!.First().GameType);
        Assert.Equal("4uh0vqwbharj", transactions!.First().UserId);
        Assert.Equal("PHP", transactions!.First().Currency);
        Assert.Equal("VN-LIVE-001", transactions!.First().GameCode);
        Assert.Equal("Baccarat Classic", transactions!.First().GameName);
        Assert.Equal(1, transactions!.First().TxStatus);
        Assert.Equal(0, transactions!.First().SettleStatus);
        Assert.Equal("2023-10-30T10:21:12Z", transactions!.First().BetTime);
        Assert.Equal("2023-10-30T10:21:12Z", transactions!.First().TxTime);
        Assert.Equal("2023-10-30T10:21:53Z", transactions!.First().UpdateTime);
        Assert.Equal("Banker", transactions!.First().BetType);
        Assert.Equal(500.0m, transactions!.First().BetAmount);
        Assert.Equal(500.0m, transactions!.First().RealBetAmount);
        Assert.Equal(500.0m, transactions!.First().Turnover);
        Assert.Equal(975.0m, transactions!.First().WinAmount);
        Assert.Equal(975.0m, transactions!.First().RealWinAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotBetAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotWinAmount);
        Assert.Equal(response["transactions"]!.AsArray()!.FirstOrDefault()!.ToJsonString(), transactions!.First().AdditionalData);
    }
}
