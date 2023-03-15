using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest.ApplicationServices;

[TestClass]
public class TransactionByTxTimeGetServiceUnitTest
{
    [TestMethod]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var platform = "SEXYBCRT";
        var startTime = DateTimeOffset.Now.AddMinutes(-5);
        var endTime = DateTimeOffset.Now;

        var query = new TransactionByTxTimeQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            Platform: platform,
            StartTime: startTime,
            EndTime: endTime);

        var fakeLogger = NullLogger<TransactionByTxTimeGetService>.Instance;
        var fakeClient = Substitute.For<IGameRecordApiClient>();

        var result = new GetTransactionByTxTimeResult(
            Success: true,
            Transactions: new GetTransactionByTxTimeTransaction[] {
                new GetTransactionByTxTimeTransaction(){
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
            });
        _ = fakeClient.GetTransactionByTxTimeAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(platform),
            Arg.Is(startTime),
            Arg.Is(endTime)).Returns(ValueTask.FromResult(result));

        var service = new TransactionByTxTimeGetService(
            fakeLogger,
            fakeClient);

        var actual = await service.QueryAsync(query).ToArrayAsync().ConfigureAwait(false);

        Assert.IsNotNull(actual);
        Assert.AreEqual($"{result.Transactions!.First().Platform}-{result.Transactions!.First().PlatformTxId}", actual.First().ExternalRoundId);
    }
}
