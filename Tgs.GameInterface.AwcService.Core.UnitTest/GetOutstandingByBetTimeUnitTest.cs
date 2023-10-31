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

public class GetOutstandingByBetTimeUnitTest
{
    [Fact]
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
            transactions = new JsonArray()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getOutstandingByBetTime")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var client = new GameRecordApiClient(fakeLog, fakeHttpClient);

        var transactions = await client.GetOutstandingByBetTimeAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            platform: platform,
            startTime: startTime,
            endTime: endTime)
            .ToArrayAsync()
            ?? Enumerable.Empty<GetOutstandingByBetTimeTransaction>();

        Assert.False(transactions.Any());
    }

    [Fact]
    public async Task SV388_Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        string platform = "SV388";
        DateTimeOffset startTime = DateTimeOffset.Now.AddMinutes(-5);
        DateTimeOffset endTime = DateTimeOffset.Now;

        var response = new JsonObject
        {
            ["status"] = ((int)GameApiClientError.Success).ToString("d4"),
            ["transactions"] = new JsonArray
            {
                new JsonObject
                {
                    ["gameType"] = "LIVE",
                    ["gameInfo"] = "{\"arenaCode\":\"_FG1\",\"odds\":\"0.92\",\"matchno\":2,\"location\":\"PHI\",\"realBetAmount\":-10.0,\"live\":0,\"matchId\":\"957416\",\"eventDate\":\"2023-10-30T16:00:00.000+0000\"}",
                    ["realBetAmount"] = 10,
                    ["userId"] = "4ucmqplxb029",
                    ["betType"] = "MERON",
                    ["betAmount"] = 10,
                    ["gameName"] = "CockFight_PHI",
                    ["platformTxId"] = "TXN1150171151",
                    ["betTime"] = "2023-10-31T03:47:00Z",
                    ["gameCode"] = "SV-LIVE-001",
                    ["currency"] = "CNY",
                    ["jackpotBetAmount"] = 0,
                    ["roundId"] = "957416"
                }
            }
        };

        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getOutstandingByBetTime")
        .Respond(HttpStatusCode.OK, new StringContent(response.ToJsonString()));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var client = new GameRecordApiClient(fakeLog, fakeHttpClient);

        var transactions = await client.GetOutstandingByBetTimeAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            platform: platform,
            startTime: startTime,
            endTime: endTime)
            .ToArrayAsync()
            ?? Enumerable.Empty<GetOutstandingByBetTimeTransaction>();

        Assert.True(transactions.Any());
        Assert.Equal("TXN1150171151", transactions!.First().PlatformTxId);
        Assert.Equal("957416", transactions!.First().RoundId);
        Assert.Equal("LIVE", transactions!.First().GameType);
        Assert.Equal("4ucmqplxb029", transactions!.First().UserId);
        Assert.Equal("CNY", transactions!.First().Currency);
        Assert.Equal("SV-LIVE-001", transactions!.First().GameCode);
        Assert.Equal("CockFight_PHI", transactions!.First().GameName);
        Assert.Equal("2023-10-31T03:47:00Z", transactions!.First().BetTime);
        Assert.Equal("MERON", transactions!.First().BetType);
        Assert.Equal(10.0m, transactions!.First().BetAmount);
        Assert.Equal(10.0m, transactions!.First().RealBetAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotBetAmount);
        Assert.Equal(response["transactions"]!.AsArray()!.FirstOrDefault()!.ToJsonString(), transactions!.First().AdditionalData);
    }
}
