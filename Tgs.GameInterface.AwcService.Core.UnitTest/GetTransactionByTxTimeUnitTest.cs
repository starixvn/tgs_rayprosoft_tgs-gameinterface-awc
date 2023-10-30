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

public class GetTransactionByTxTimeUnitTest
{
    [Fact]
    public async Task No_Transactions_Data()

    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var startTime = DateTimeOffset.Now.AddMinutes(-5);
        var endTime = DateTimeOffset.Now;

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            transactions = new JsonArray()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getTransactionByTxTime")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var client = new GameRecordApiClient(fakeLog, fakeHttpClient);

        var transactions = await client.GetTransactionByTxTimeAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            platform: platform,
            startTime: startTime,
            endTime: endTime)
            .ToArrayAsync()
            ?? Enumerable.Empty<GetTransactionByTxTimeTransaction>();

        Assert.False(transactions.Any());
    }

    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var startTime = DateTimeOffset.Now.AddMinutes(-5);
        var endTime = DateTimeOffset.Now;

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            transactions = new[]
            {
                new
                {
                    gameType= "LIVE",
                    winAmount= 97.5,
                    txTime= "2021-03-10T15:49:00+08:00",
                    settleStatus= 0,
                    gameInfo= "{\"result\":[\"C13\",\"D06\",\"\",\"D11\",\"D04\",\"C10\"],\"roundStartTime\":\"03/11/2021 13:35:57.648\",\"winner\":\"BANKER\",\"ip\":\"192.172.0.1\",\"odds\":-1.0,\"streamerId\":\"\",\"tableId\":1,\"dealerDomain\":\"Mexico\",\"winLoss\":-10.0,\"status\":\"LOSE\"}",
                    realWinAmount= 97.5,
                    updateTime= "2021-03-10T15:49:24+08:00",
                    realBetAmount= 50,
                    userId= "testuser",
                    betType= "Banker",
                    platform= "SEXYBCRT",
                    txStatus= 1,
                    betAmount= 50,
                    gameName= "BaccaratClassic",
                    platformTxId= "BAC-133992630",
                    betTime= "2021-03-10T15:49:00+08:00",
                    gameCode= "MX-LIVE-001",
                    currency= "CNY",
                    jackpotWinAmount= 0,
                    jackpotBetAmount= 0,
                    turnover= 47.5,
                    roundId= "Mexico-01-GA355950059"}
            }
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getTransactionByTxTime")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var client = new GameRecordApiClient(fakeLog, fakeHttpClient);

        var transactions = await client.GetTransactionByTxTimeAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            platform: platform,
            startTime: startTime,
            endTime: endTime)
            .ToArrayAsync()
            ?? Enumerable.Empty<GetTransactionByTxTimeTransaction>();

        Assert.True(transactions.Any());
        Assert.Equal("BAC-133992630", transactions!.First().PlatformTxId);
        Assert.Equal("Mexico-01-GA355950059", transactions!.First().RoundId);
        Assert.Equal("LIVE", transactions!.First().GameType);
        Assert.Equal("testuser", transactions!.First().UserId);
        Assert.Equal("CNY", transactions!.First().Currency);
        Assert.Equal("MX-LIVE-001", transactions!.First().GameCode);
        Assert.Equal("BaccaratClassic", transactions!.First().GameName);
        Assert.Equal(1, transactions!.First().TxStatus);
        Assert.Equal(0, transactions!.First().SettleStatus);
        Assert.Equal("2021-03-10T15:49:00+08:00", transactions!.First().BetTime);
        Assert.Equal("2021-03-10T15:49:00+08:00", transactions!.First().TxTime);
        Assert.Equal("2021-03-10T15:49:24+08:00", transactions!.First().UpdateTime);
        Assert.Equal("Banker", transactions!.First().BetType);
        Assert.Equal(50.0m, transactions!.First().BetAmount);
        Assert.Equal(50.0m, transactions!.First().RealBetAmount);
        Assert.Equal(47.5m, transactions!.First().Turnover);
        Assert.Equal(97.5m, transactions!.First().WinAmount);
        Assert.Equal(97.5m, transactions!.First().RealWinAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotBetAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotWinAmount);
    }

    [Fact]
    public async Task FASTSPIN_Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "FASTSPIN";
        var startTime = DateTimeOffset.Now.AddMinutes(-5);
        var endTime = DateTimeOffset.Now;

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            transactions = new[]
            {
                new
                {
                    gameType= "SLOT",
                    winAmount= 1,
                    txTime= "2023-10-30T16:20:22+08:00",
                    settleStatus= 0,
                    gameInfo= "{\"refTicketIds\":[\"10509871043\",\"10509871044\"],\"isEndRound\":true,\"isBuyFreeSpin\":false}",
                    realWinAmount= 1,
                    updateTime= "2023-10-30T16:20:22+08:00",
                    realBetAmount= 10,
                    userId= "4uh0oolsfiqw",
                    platform= "FASTSPIN",
                    txStatus= 1,
                    betAmount= 10,
                    gameName= "Royale House",
                    platformTxId= "20231030162022282246794",
                    betTime="2023-10-30T16:20:22+08:00",
                    gameCode= "FastSpin-SLOT-001",
                    currency= "PHP",
                    jackpotWinAmount= 0,
                    jackpotBetAmount= 0,
                    turnover= 10,
                    roundId= "20231030162022193246671"}
            }
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/fetch/gzip/getTransactionByTxTime")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameRecordApiClient>.Instance;
        var client = new GameRecordApiClient(fakeLog, fakeHttpClient);

        var transactions = await client.GetTransactionByTxTimeAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            platform: platform,
            startTime: startTime,
            endTime: endTime)
            .ToArrayAsync()
            ?? Enumerable.Empty<GetTransactionByTxTimeTransaction>();

        Assert.True(transactions.Any());
        Assert.Equal("20231030162022282246794", transactions!.First().PlatformTxId);
        Assert.Equal("20231030162022193246671", transactions!.First().RoundId);
        Assert.Equal("SLOT", transactions!.First().GameType);
        Assert.Equal("4uh0oolsfiqw", transactions!.First().UserId);
        Assert.Equal("PHP", transactions!.First().Currency);
        Assert.Equal("FastSpin-SLOT-001", transactions!.First().GameCode);
        Assert.Equal("Royale House", transactions!.First().GameName);
        Assert.Equal(1, transactions!.First().TxStatus);
        Assert.Equal(0, transactions!.First().SettleStatus);
        Assert.Equal("2023-10-30T16:20:22+08:00", transactions!.First().BetTime);
        Assert.Equal("2023-10-30T16:20:22+08:00", transactions!.First().TxTime);
        Assert.Equal("2023-10-30T16:20:22+08:00", transactions!.First().UpdateTime);
        Assert.Equal(string.Empty, transactions!.First().BetType);
        Assert.Equal(10.0m, transactions!.First().BetAmount);
        Assert.Equal(10.0m, transactions!.First().RealBetAmount);
        Assert.Equal(10.0m, transactions!.First().Turnover);
        Assert.Equal(1m, transactions!.First().WinAmount);
        Assert.Equal(1m, transactions!.First().RealWinAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotBetAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotWinAmount);
    }
}
