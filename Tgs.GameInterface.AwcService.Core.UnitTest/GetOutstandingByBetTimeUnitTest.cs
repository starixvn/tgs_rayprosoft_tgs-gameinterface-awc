using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;

namespace Tgs.GameInterface.AwcService.Core.UnitTest;

[TestClass]
public class GetOutstandingByBetTimeUnitTest
{
    [TestMethod]
    public async Task No_Transactions_Data()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        string platform = "SABA";
        DateTimeOffset startTime = DateTimeOffset.Now.AddMinutes(-5);
        DateTimeOffset endTime = DateTimeOffset.Now;

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            transactions = default(Nullable)
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getOutstandingByBetTime")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var client = new GameRecordApiClient(fakeLog, fakeHttpClient);

        var result = await client.GetOutstandingByBetTimeAsync(apiUrl, agentId, cert, platform, startTime, endTime);

        Assert.IsTrue(result.Success);
        Assert.IsFalse(result.Transactions.Any());
    }

    [TestMethod]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        string platform = "SEXYBCRT";
        DateTimeOffset startTime = DateTimeOffset.Now.AddMinutes(-5);
        DateTimeOffset endTime = DateTimeOffset.Now;

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            transactions = new[]
            {
                new
                {
                    gameType= "VIRTUAL",
                    gameInfo= "{\"sportTypeName\":\"Soccer\",\"oddsId\":\"321097418\",\"sportType\":\"1\",\"homeName\":\"VfL Wolfsburg (V)\",\"awayId\":\"675922\",\"oddsType\":\"4\",\"betChoice\":\"h\",\"leagueName\":\"SABA CLUB FRIENDLY Virtual PES 21 - 15 Mins Play\",\"awayName\":\"FSV Mainz 05 (V)\",\"leagueId\":\"95730\",\"odds\":\"0.75\",\"homeId\":\"674922\"}",
                    realBetAmount= 1,
                    userId= "testuser",
                    betType= "1",
                    betAmount= 1,
                    gameName= "Virtual Sports",
                    platformTxId= "7623",
                    betTime= "2021-03-10T17:36:36+08:00",
                    gameCode= "SABA-VIRTUAL-001",
                    currency= "THB",
                    jackpotBetAmount= 0,
                    roundId= "42186783"
                }
            }
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getOutstandingByBetTime")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var client = new GameRecordApiClient(fakeLog, fakeHttpClient);

        var result = await client.GetOutstandingByBetTimeAsync(apiUrl, agentId, cert, platform, startTime, endTime);

        Assert.IsTrue(result.Success);
        Assert.AreEqual(response.transactions.First().roundId, result.Transactions!.First().RoundId);
    }
}
