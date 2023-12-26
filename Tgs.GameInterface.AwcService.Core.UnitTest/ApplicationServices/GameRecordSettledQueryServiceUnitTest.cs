using System;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest.ApplicationServices;

public class GameRecordSettledQueryServiceUnitTest
{
    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var timeFrom = DateTimeOffset.Now;

        var query = new GameRecordSettledQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            Platform: platform,
            TimeFrom: timeFrom);

        var fakeClient = Substitute.For<IGameRecordApiClient>();

        var transactions = new GetTransactionByUpdateDateTransaction[] {
                new(){
                    Platform= "SEXYBCRT",
                    PlatformTxId= "BAC-133992630",
                    GameType= "LIVE",
                    GameCode= "MX-LIVE-001",
                    GameName= "BaccaratClassic",
                    RoundId= "Mexico-01-GA355950059",
                    UserId="testuser",
                    Currency= "CNY",
                    TxStatus= 1,
                    SettleStatus= 0,
                    BetTime= "2021-03-10T15:49:00+08:00",
                    TxTime= "2021-03-10T15:49:00+08:00",
                    UpdateTime= "2021-03-10T15:49:24+08:00",
                    BetType= "Banker",
                    BetAmount= 50m,
                    RealBetAmount= 50m,
                    Turnover= 47.5m,
                    WinAmount= 97.5m,
                    RealWinAmount= 97.5m,
                    JackpotBetAmount= 0,
                    JackpotWinAmount= 0,
                    GameInfo= "{\"result\":[\"C13\",\"D06\",\"\",\"D11\",\"D04\",\"C10\"],\"roundStartTime\":\"03/11/2021 13:35:57.648\",\"winner\":\"BANKER\",\"ip\":\"192.172.0.1\",\"odds\":-1.0,\"streamerId\":\"\",\"tableId\":1,\"dealerDomain\":\"Mexico\",\"winLoss\":-10.0,\"status\":\"LOSE\"}"
                }
            };
        _ = fakeClient.GetTransactionByUpdateDateAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(platform),
            Arg.Is(timeFrom))
            .Returns(transactions.ToAsyncEnumerable());

        var service = new GameRecordSettledQueryService(
            fakeClient);

        var actual = await service.QueryAsync(
            query: query)
            .ToArrayAsync()
            ?? Enumerable.Empty<GameRecordResult>();

        Assert.NotNull(actual);
        Assert.NotEmpty(transactions);
        Assert.Equal("SEXYBCRT-BAC-133992630", actual!.First().ExternalRoundId);
        Assert.Equal("BAC-133992630", actual!.First().PlatformTxId);
        Assert.Equal("Mexico-01-GA355950059", actual!.First().RoundId);
        Assert.Equal("LIVE", actual!.First().GameType);
        Assert.Equal("testuser", actual!.First().UserId);
        Assert.Equal("CNY", actual!.First().Currency);
        Assert.Equal("MX-LIVE-001", actual!.First().GameCode);
        Assert.Equal("BaccaratClassic", actual!.First().GameName);
        Assert.Equal(1, actual!.First().TxStatus);
        Assert.Equal(0, actual!.First().SettleStatus);
        Assert.Equal("2021-03-10T15:49:00+08:00", actual!.First().BetTime);
        Assert.Equal("2021-03-10T15:49:00+08:00", actual!.First().TxTime);
        Assert.Equal("2021-03-10T15:49:24+08:00", actual!.First().UpdateTime);
        Assert.Equal("Banker", actual!.First().BetType);
        Assert.Equal(50.0m, actual!.First().BetAmount);
        Assert.Equal(50.0m, transactions!.First().RealBetAmount);
        Assert.Equal(47.5m, transactions!.First().Turnover);
        Assert.Equal(97.5m, transactions!.First().WinAmount);
        Assert.Equal(97.5m, transactions!.First().RealWinAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotBetAmount);
        Assert.Equal(0.0m, transactions!.First().JackpotWinAmount);
    }
}
