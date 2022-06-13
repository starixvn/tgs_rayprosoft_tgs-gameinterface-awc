using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest
{
    [TestClass]
    public class TransactionByUpdateDateGetServiceUnitTest
    {
        [TestMethod]
        public async Task Normal_Process()
        {
            var apiUrl = new Uri("http://localhost/");
            var agentId = "testagentid";
            var cert = "testcert";
            var platform = "SEXYBCRT";
            var timeFrom = DateTimeOffset.Now;

            var query = new TransactionByUpdateDateQuery(
                ApiUrl: apiUrl,
                AgentId: agentId,
                Cert: cert,
                Platform: platform,
                TimeFrom: timeFrom);

            var fakeLogger = NullLogger<TransactionByUpdateDateGetService>.Instance;
            var fakeClient = Substitute.For<IGameRecordApiClient>();

            var result = new GetTransactionByUpdateDateResult(
                Success: true,
                Transactions: new GetTransactionByUpdateDateTransaction[] {
                    new GetTransactionByUpdateDateTransaction(){
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
            _ = fakeClient.GetTransactionByUpdateDateAsync(
                Arg.Is(apiUrl),
                Arg.Is(agentId),
                Arg.Is(cert),
                Arg.Is(platform),
                Arg.Is(timeFrom)).Returns(ValueTask.FromResult(result));

            var service = new TransactionByUpdateDateGetService(
                fakeLogger,
                fakeClient);

            var actual = await service.QueryAsync(query).ToArrayAsync().ConfigureAwait(false);

            Assert.IsNotNull(actual);
            Assert.AreEqual($"{result.Transactions!.First().Platform}-{result.Transactions!.First().PlatformTxId}", actual.First().ExternalRoundId);
        }
    }
}
