using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RichardSzalay.MockHttp;
using Tgs.GameInterface.AwcService.Core;
using Tgs.Logging;

namespace Tgs.GameInterface.AwcService.Repositories.UnitTest;

[TestClass]
public class GetTransactionByUpdateDateUnitTest
{
    [TestMethod]
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
            transactions = default(Nullable)
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getTransactionByUpdateDate")
        .Respond(HttpStatusCode.OK, content: new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var fakeTgsLog = Substitute.For<ITgsLog>();

        var client = new GameRecordApiClient(fakeHttpClient, fakeLog, fakeTgsLog);

        var result = await client.GetTransactionByUpdateDateAsync(apiUrl, agentId, cert, platform, timeFrom, TransactionStatus.Settled);

        Assert.IsTrue(result.Success);
        Assert.IsFalse(result.Transactions.Any());
    }

    [TestMethod]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var timeFrom = DateTimeOffset.Now.AddMinutes(-2);

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            transactions = new[]
            {
                new
                {
                    gameType= "LIVE",
                    winAmount= 0,
                    txTime= "2021-03-11T10:05:33+08:00",
                    settleStatus= 0,
                    gameInfo= "{\"result\":[\"C13\",\"D06\",\"\",\"D11\",\"D04\",\"C10\"],\"roundStartTime\":\"03/11/2021 13:35:57.648\",\"winner\":\"BANKER\",\"ip\":\"192.172.0.1\",\"odds\":-1.0,\"streamerId\":\"\",\"tableId\":1,\"dealerDomain\":\"Mexico\",\"winLoss\":-20.0,\"status\":\"LOSE\"}",
                    realWinAmount= 0,
                    updateTime= "2021-03-11T13:36:35+08:00",
                    realBetAmount= 20,
                    userId= "testuser",
                    betType= "Banker",
                    platform= "SEXYBCRT",
                    txStatus= 1,
                    betAmount= 20,
                    gameName= "BaccaratClassic",
                    platformTxId= "BAC-134152039",
                    betTime= "2021-03-11T13:36:06+08:00",
                    gameCode= "MX-LIVE-001",
                    currency= "CNY",
                    jackpotWinAmount= 0,
                    jackpotBetAmount= 0,
                    turnover= 20,
                    roundId= "Mexico-01-GA356200030"
                }
            }
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getTransactionByUpdateDate")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var fakeTgsLog = Substitute.For<ITgsLog>();
        var client = new GameRecordApiClient(fakeHttpClient, fakeLog, fakeTgsLog);

        var result = await client.GetTransactionByUpdateDateAsync(apiUrl, agentId, cert, platform, timeFrom);

        Assert.IsTrue(result.Success);
        Assert.AreEqual(response.transactions.First().roundId, result.Transactions!.First().RoundId);
    }

    [TestMethod]
    public async Task Normal_ProcessByStatus()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var timeFrom = DateTimeOffset.Now.AddMinutes(-2);

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            transactions = new[]
            {
                new
                {
                    gameType= "LIVE",
                    winAmount= 0,
                    txTime= "2021-03-11T10:05:33+08:00",
                    settleStatus= 0,
                    gameInfo= "{\"result\":[\"C13\",\"D06\",\"\",\"D11\",\"D04\",\"C10\"],\"roundStartTime\":\"03/11/2021 13:35:57.648\",\"winner\":\"BANKER\",\"ip\":\"192.172.0.1\",\"odds\":-1.0,\"streamerId\":\"\",\"tableId\":1,\"dealerDomain\":\"Mexico\",\"winLoss\":-20.0,\"status\":\"LOSE\"}",
                    realWinAmount= 0,
                    updateTime= "2021-03-11T13:36:35+08:00",
                    realBetAmount= 20,
                    userId= "testuser",
                    betType= "Banker",
                    platform= "SEXYBCRT",
                    txStatus= 1,
                    betAmount= 20,
                    gameName= "BaccaratClassic",
                    platformTxId= "BAC-134152039",
                    betTime= "2021-03-11T13:36:06+08:00",
                    gameCode= "MX-LIVE-001",
                    currency= "CNY",
                    jackpotWinAmount= 0,
                    jackpotBetAmount= 0,
                    turnover= 20,
                    roundId= "Mexico-01-GA356200030"
                }
            }
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getTransactionByUpdateDate")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var fakeTgsLog = Substitute.For<ITgsLog>();
        var client = new GameRecordApiClient(fakeHttpClient, fakeLog, fakeTgsLog);

        var result = await client.GetTransactionByUpdateDateAsync(apiUrl, agentId, cert, platform, timeFrom, TransactionStatus.Settled);

        Assert.IsTrue(result.Success);
        Assert.AreEqual(response.transactions.First().roundId, result.Transactions!.First().RoundId);
    }
}
