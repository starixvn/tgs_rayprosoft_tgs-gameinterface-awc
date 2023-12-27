using System;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.Core.Models;

namespace Tgs.GameInterface.Awc.Core.UnitTest.ApplicationServices;

public class GameRecordUnsettledQueryServiceUnitTest
{
    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var startTime = DateTimeOffset.Now.AddMinutes(-5);
        var endTime = DateTimeOffset.Now;

        var query = new GameWagerUnsettledQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            Platform: platform,
            StartTime: startTime,
            EndTime: endTime);

        var fakeClient = Substitute.For<IGameRecordApiClient>();

        var transactions = new GetOutstandingByBetTimeTransaction[] {
                new(){
                    PlatformTxId= "7623",
                    GameType= "VIRTUAL",
                    GameCode= "SABA-VIRTUAL-001",
                    GameName= "Virtual Sports",
                    RoundId= "42186783",
                    UserId= "testuser",
                    Currency= "THB",
                    BetTime= "2021-03-10T17:36:36+08:00",
                    BetType= "1",
                    BetAmount= 1,
                    RealBetAmount= 1,
                    JackpotBetAmount= 0,
                    GameInfo= "{\"sportTypeName\":\"Soccer\",\"oddsId\":\"321097418\",\"sportType\":\"1\",\"homeName\":\"VfL Wolfsburg (V)\",\"awayId\":\"675922\",\"oddsType\":\"4\",\"betChoice\":\"h\",\"leagueName\":\"SABA CLUB FRIENDLY Virtual PES 21 - 15 Mins Play\",\"awayName\":\"FSV Mainz 05 (V)\",\"leagueId\":\"95730\",\"odds\":\"0.75\",\"homeId\":\"674922\"}"
                }
            };
        _ = fakeClient.GetOutstandingByBetTimeAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(platform),
            Arg.Is(startTime),
            Arg.Is(endTime))
            .Returns(transactions.ToAsyncEnumerable());

        var service = new GameWagerUnsettledQueryService(
            fakeClient);

        var actual = await service.QueryAsync(
            query)
            .ToArrayAsync()
            ?? Enumerable.Empty<GameWagerResult>();

        Assert.NotNull(actual);
        Assert.NotEmpty(transactions);
        Assert.Equal("42186783", actual!.First().ExternalRoundId);
        Assert.Equal(string.Format("{0}-{1}", "SEXYBCRT", "7623"), actual!.First().ExternalWagerId);
        Assert.Equal("SABA-VIRTUAL-001", actual!.First().ExternalGameId);
        Assert.Equal("testuser", actual!.First().PlayerCode);
        Assert.False(actual!.First().IsClosed);
        Assert.False(actual!.First().IsCanceled);
        Assert.False(actual!.First().IsVoid);
        Assert.False(actual!.First().IsCashout);
        Assert.Equal(DateTimeOffset.Parse("2021-03-10T17:36:36+08:00"), actual!.First().ExternalCreatedOn);
        Assert.Equal(DateTimeOffset.UnixEpoch, actual!.First().ExternalClosedOn);
        Assert.Equal(1.0m, actual!.First().Bet);
        Assert.Equal(1.0m, actual!.First().ValidBet);
        Assert.Equal(0.0m, actual!.First().Settle);
        Assert.Equal(0.0m, actual!.First().Turnover);
        Assert.Equal(0.0m, actual!.First().WinLoss);
    }
}
