using System;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.Core.Models;

namespace Tgs.GameInterface.Awc.Core.UnitTest.ApplicationServices;

public class GameRecordSettledQueryServiceUnitTest
{
    [Fact]
    public async Task Horsebook_Is_Canceled()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "HORSEBOOK";
        var timeFrom = DateTimeOffset.Now;

        var query = new GameWagerSettledQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            Platform: platform,
            TimeFrom: timeFrom);

        var fakeClient = Substitute.For<IGameRecordApiClient>();
        var utensil = new GameWagerUtensil();

        var transactions = new GetTransactionByUpdateDateTransaction[] {
                new(){
                    Platform= "HORSEBOOK",
                    PlatformTxId= "WIN/PLC/FO-22020414",
                    GameType= "LIVE",
                    GameCode= "HRB-LIVE-001",
                    GameName= "Horsebook",
                    RoundId= "5597566",
                    UserId="4uko1dmwroak",
                    Currency= "HKD",
                    TxStatus= 2,
                    SettleStatus= -1,
                    BetTime= "2023-09-19T03:17:19Z",
                    TxTime= "2023-09-19T03:17:19Z",
                    UpdateTime= "2023-09-19T04:06:20Z",
                    BetType= "WIN",
                    BetAmount= 50m,
                    RealBetAmount= 50m,
                    Turnover= 0m,
                    WinAmount= 0m,
                    RealWinAmount= 0m,
                    JackpotBetAmount= 0m,
                    JackpotWinAmount= 0m,
                    GameInfo= "{\"runnerNo\":\"2\",\"raceId\":\"5597566\",\"foBetRule\":0,\"raceType\":\"60A\",\"locationName\":\"Hobart\",\"locationNameCn\":\"霍巴特\",\"countryNameCn\":\"澳洲(狗)\",\"gameMethod\":\"WIN_PLC_FO\",\"fo\":true,\"userId\":\"12a4uko1dmwroak\",\"stake\":50,\"runnerName\":\"ARCADIAN ROXY\",\"locationId\":60,\"countryCode\":\"AU\",\"odds\":3.7,\"categoryTypeID\":\"1\",\"currency\":\"HKD\",\"countryName\":\"AU (Dog)\",\"runnerType\":\"Greyhound\",\"currencyID\":2,\"raceDate\":\"19-09-2023\",\"raceNo\":3,\"txnId\":22020414,\"voidType\":2,\"realWinAmt\":0}"
                }
            };
        _ = fakeClient.GetTransactionByUpdateDateAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(platform),
            Arg.Is(timeFrom))
            .Returns(transactions.ToAsyncEnumerable());

        var service = new GameWagerSettledQueryService(
            fakeClient,
            utensil);

        var actual = await service.QueryAsync(
            query: query)
            .ToArrayAsync()
            ?? Enumerable.Empty<GameWagerResult>();

        Assert.NotNull(actual);
        Assert.NotEmpty(transactions);
        Assert.Equal("5597566", actual!.First().ExternalRoundId);
        Assert.Equal(string.Format("{0}-{1}", "HORSEBOOK", "WIN/PLC/FO-22020414"), actual!.First().ExternalWagerId);
        Assert.Equal("HRB-LIVE-001", actual!.First().ExternalGameId);
        Assert.Equal("4uko1dmwroak", actual!.First().PlayerCode);
        Assert.True(actual!.First().IsClosed);
        Assert.True(actual!.First().IsCanceled);
        Assert.False(actual!.First().IsVoid);
        Assert.False(actual!.First().IsCashout);
        Assert.Equal(DateTimeOffset.Parse("2023-09-19T03:17:19Z"), actual!.First().ExternalCreatedOn);
        Assert.Equal(DateTimeOffset.Parse("2023-09-19T03:17:19Z"), actual!.First().ExternalClosedOn);
        Assert.Equal(50.0m, actual!.First().Bet);
        Assert.Equal(50.0m, actual!.First().ValidBet);
        Assert.Equal(0.0m, actual!.First().Settle);
        Assert.Equal(0.0m, actual!.First().Turnover);
        Assert.Equal(0.0m, actual!.First().WinLoss);
    }

    [Fact]
    public async Task Horsebook_Is_Cashout()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "HORSEBOOK";
        var timeFrom = DateTimeOffset.Now;

        var query = new GameWagerSettledQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            Platform: platform,
            TimeFrom: timeFrom);

        var fakeClient = Substitute.For<IGameRecordApiClient>();
        var utensil = new GameWagerUtensil();

        var transactions = new GetTransactionByUpdateDateTransaction[] {
                new(){
                    Platform= "HORSEBOOK",
                    PlatformTxId= "WIN/PLC-21999519",
                    GameType= "LIVE",
                    GameCode= "HRB-LIVE-001",
                    GameName= "Horsebook",
                    RoundId= "5595844",
                    UserId="4uko1dmwroak",
                    Currency= "HKD",
                    TxStatus= 3,
                    SettleStatus= -1,
                    BetTime= "2023-09-17T09:52:08Z",
                    TxTime= "2023-09-17T09:52:08Z",
                    UpdateTime= "2023-09-17T10:00:30Z",
                    BetType= "WIN",
                    BetAmount= 50m,
                    RealBetAmount= 50m,
                    Turnover= 0m,
                    WinAmount= 0m,
                    RealWinAmount= 0m,
                    JackpotBetAmount= 0m,
                    JackpotWinAmount= 0m,
                    GameInfo= "{\"runnerNo\":\"3\",\"raceId\":\"5595844\",\"foBetRule\":0,\"raceType\":\"4S\",\"locationName\":\"Malaysia\",\"locationNameCn\":\"马来西亚\",\"countryNameCn\":\"雪兰莪\",\"gameMethod\":\"WIN_PLC\",\"userId\":\"12a4uko1dmwroak\",\"stake\":50,\"runnerName\":\"Jockey King\",\"locationId\":4,\"countryCode\":\"MY\",\"categoryTypeID\":\"1\",\"currency\":\"HKD\",\"countryName\":\"Selangor\",\"runnerType\":\"Horse\",\"currencyID\":2,\"raceDate\":\"17-09-2023\",\"raceNo\":12,\"txnId\":21999519,\"voidType\":3,\"realWinAmt\":0}"
                }
            };
        _ = fakeClient.GetTransactionByUpdateDateAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(platform),
            Arg.Is(timeFrom))
            .Returns(transactions.ToAsyncEnumerable());

        var service = new GameWagerSettledQueryService(
            fakeClient,
            utensil);

        var actual = await service.QueryAsync(
            query: query)
            .ToArrayAsync()
            ?? Enumerable.Empty<GameWagerResult>();

        Assert.NotNull(actual);
        Assert.NotEmpty(transactions);
        Assert.Equal("5595844", actual!.First().ExternalRoundId);
        Assert.Equal(string.Format("{0}-{1}", "HORSEBOOK", "WIN/PLC-21999519"), actual!.First().ExternalWagerId);
        Assert.Equal("HRB-LIVE-001", actual!.First().ExternalGameId);
        Assert.Equal("4uko1dmwroak", actual!.First().PlayerCode);
        Assert.True(actual!.First().IsClosed);
        Assert.True(actual!.First().IsCanceled);
        Assert.False(actual!.First().IsVoid);
        Assert.True(actual!.First().IsCashout);
        Assert.Equal(DateTimeOffset.Parse("2023-09-17T09:52:08Z"), actual!.First().ExternalCreatedOn);
        Assert.Equal(DateTimeOffset.Parse("2023-09-17T09:52:08Z"), actual!.First().ExternalClosedOn);
        Assert.Equal(50.0m, actual!.First().Bet);
        Assert.Equal(50.0m, actual!.First().ValidBet);
        Assert.Equal(0.0m, actual!.First().Settle);
        Assert.Equal(0.0m, actual!.First().Turnover);
        Assert.Equal(0.0m, actual!.First().WinLoss);
    }

    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var timeFrom = DateTimeOffset.Now;

        var query = new GameWagerSettledQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            Platform: platform,
            TimeFrom: timeFrom);

        var fakeClient = Substitute.For<IGameRecordApiClient>();
        var utensil = new GameWagerUtensil();

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

        var service = new GameWagerSettledQueryService(
            fakeClient,
            utensil);

        var actual = await service.QueryAsync(
            query: query)
            .ToArrayAsync()
            ?? Enumerable.Empty<GameWagerResult>();

        Assert.NotNull(actual);
        Assert.NotEmpty(transactions);
        Assert.Equal("Mexico-01-GA355950059", actual!.First().ExternalRoundId);
        Assert.Equal(string.Format("{0}-{1}", "SEXYBCRT", "BAC-133992630"), actual!.First().ExternalWagerId);
        Assert.Equal("MX-LIVE-001", actual!.First().ExternalGameId);
        Assert.Equal("testuser", actual!.First().PlayerCode);
        Assert.True(actual!.First().IsClosed);
        Assert.False(actual!.First().IsCanceled);
        Assert.False(actual!.First().IsVoid);
        Assert.False(actual!.First().IsCashout);
        Assert.Equal(DateTimeOffset.Parse("2021-03-10T15:49:00+08:00"), actual!.First().ExternalCreatedOn);
        Assert.Equal(DateTimeOffset.Parse("2021-03-10T15:49:00+08:00"), actual!.First().ExternalClosedOn);
        Assert.Equal(50.0m, actual!.First().Bet);
        Assert.Equal(50.0m, actual!.First().ValidBet);
        Assert.Equal(97.5m, actual!.First().Settle);
        Assert.Equal(47.5m, actual!.First().Turnover);
        Assert.Equal(47.5m, actual!.First().WinLoss);
    }

    [Fact]
    public async Task SEXYBCRT_Is_Canceled()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var timeFrom = DateTimeOffset.Now;

        var query = new GameWagerSettledQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            Platform: platform,
            TimeFrom: timeFrom);

        var fakeClient = Substitute.For<IGameRecordApiClient>();
        var utensil = new GameWagerUtensil();

        var transactions = new GetTransactionByUpdateDateTransaction[] {
                new(){
                    Platform= "SEXYBCRT",
                    PlatformTxId= "RL-7217367390",
                    GameType= "LIVE",
                    GameCode= "MX-LIVE-009",
                    GameName= "Roulette",
                    RoundId= "Mexico-71-GA186810087",
                    UserId="4uh7hcpwwpok",
                    Currency= "PHP",
                    TxStatus= 2,
                    SettleStatus= -1,
                    BetTime= "2023-12-20T16:02:05Z",
                    TxTime= "2023-12-20T16:02:05Z",
                    UpdateTime= "2023-12-20T16:05:44Z",
                    BetType= "Direct 9",
                    BetAmount= 20m,
                    RealBetAmount= 20m,
                    Turnover= 0m,
                    WinAmount= 0m,
                    RealWinAmount= 0m,
                    JackpotBetAmount= 0m,
                    JackpotWinAmount= 0m,
                    GameInfo= "{\"roundStartTime\":\"12/21/2023 00:01:38.597\",\"tableId\":71,\"denyTime\":\"12/21/2023 00:02:10.097\",\"dealerDomain\":\"Mexico\",\"voidType\":2,\"realWinAmt\":0}"
                }
            };
        _ = fakeClient.GetTransactionByUpdateDateAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(platform),
            Arg.Is(timeFrom))
            .Returns(transactions.ToAsyncEnumerable());

        var service = new GameWagerSettledQueryService(
            fakeClient,
            utensil);

        var actual = await service.QueryAsync(
            query: query)
            .ToArrayAsync()
            ?? Enumerable.Empty<GameWagerResult>();

        Assert.NotNull(actual);
        Assert.NotEmpty(transactions);
        Assert.Equal("Mexico-71-GA186810087", actual!.First().ExternalRoundId);
        Assert.Equal(string.Format("{0}-{1}", "SEXYBCRT", "RL-7217367390"), actual!.First().ExternalWagerId);
        Assert.Equal("MX-LIVE-009", actual!.First().ExternalGameId);
        Assert.Equal("4uh7hcpwwpok", actual!.First().PlayerCode);
        Assert.True(actual!.First().IsClosed);
        Assert.True(actual!.First().IsCanceled);
        Assert.False(actual!.First().IsVoid);
        Assert.False(actual!.First().IsCashout);
        Assert.Equal(DateTimeOffset.Parse("2023-12-20T16:02:05Z"), actual!.First().ExternalCreatedOn);
        Assert.Equal(DateTimeOffset.Parse("2023-12-20T16:02:05Z"), actual!.First().ExternalClosedOn);
        Assert.Equal(20.0m, actual!.First().Bet);
        Assert.Equal(20.0m, actual!.First().ValidBet);
        Assert.Equal(0.0m, actual!.First().Settle);
        Assert.Equal(0.0m, actual!.First().Turnover);
        Assert.Equal(0.0m, actual!.First().WinLoss);
    }

    [Fact]
    public async Task VENUS_Is_Canceled()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "VENUS";
        var timeFrom = DateTimeOffset.Now;

        var query = new GameWagerSettledQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            Platform: platform,
            TimeFrom: timeFrom);

        var fakeClient = Substitute.For<IGameRecordApiClient>();
        var utensil = new GameWagerUtensil();

        var transactions = new GetTransactionByUpdateDateTransaction[] {
                new(){
                    Platform= "VENUS",
                    PlatformTxId= "BAC-8725938388",
                    GameType= "LIVE",
                    GameCode= "VN-LIVE-001",
                    GameName= "Baccarat Classic",
                    RoundId= "Bavet-04-GA394430051",
                    UserId="4ugru7vt1zol",
                    Currency= "PHP",
                    TxStatus= 2,
                    SettleStatus= -1,
                    BetTime= "2023-11-24T05:24:29Z",
                    TxTime= "2023-11-24T05:24:29Z",
                    UpdateTime= "2023-11-24T05:26:28Z",
                    BetType= "PlayerPair",
                    BetAmount= 100m,
                    RealBetAmount= 100m,
                    Turnover= 0m,
                    WinAmount= 0m,
                    RealWinAmount= 0m,
                    JackpotBetAmount= 0m,
                    JackpotWinAmount= 0m,
                    GameInfo= "{\"roundStartTime\":\"11/24/2023 13:24:15.911\",\"streamerId\":\"\",\"tableId\":4,\"dealerDomain\":\"Bavet\",\"voidType\":2,\"realWinAmt\":0}"
                }
            };
        _ = fakeClient.GetTransactionByUpdateDateAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(platform),
            Arg.Is(timeFrom))
            .Returns(transactions.ToAsyncEnumerable());

        var service = new GameWagerSettledQueryService(
            fakeClient,
            utensil);

        var actual = await service.QueryAsync(
            query: query)
            .ToArrayAsync()
            ?? Enumerable.Empty<GameWagerResult>();

        Assert.NotNull(actual);
        Assert.NotEmpty(transactions);
        Assert.Equal("Bavet-04-GA394430051", actual!.First().ExternalRoundId);
        Assert.Equal(string.Format("{0}-{1}", "VENUS", "BAC-8725938388"), actual!.First().ExternalWagerId);
        Assert.Equal("VN-LIVE-001", actual!.First().ExternalGameId);
        Assert.Equal("4ugru7vt1zol", actual!.First().PlayerCode);
        Assert.True(actual!.First().IsClosed);
        Assert.True(actual!.First().IsCanceled);
        Assert.False(actual!.First().IsVoid);
        Assert.False(actual!.First().IsCashout);
        Assert.Equal(DateTimeOffset.Parse("2023-11-24T05:24:29Z"), actual!.First().ExternalCreatedOn);
        Assert.Equal(DateTimeOffset.Parse("2023-11-24T05:24:29Z"), actual!.First().ExternalClosedOn);
        Assert.Equal(100.0m, actual!.First().Bet);
        Assert.Equal(100.0m, actual!.First().ValidBet);
        Assert.Equal(0.0m, actual!.First().Settle);
        Assert.Equal(0.0m, actual!.First().Turnover);
        Assert.Equal(0.0m, actual!.First().WinLoss);
    }
}
