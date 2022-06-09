using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest
{
    [TestClass]
    public class GameUnsettleTransactionGetServiceUnitTest
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

            var query = new GameUnsettleTransactionQuery(
                ApiUrl: apiUrl,
                AgentId: agentId,
                Cert: cert,
                Platform: platform,
                StartTime: startTime,
                EndTime: endTime);

            var fakeClient = Substitute.For<IGameRecordApiClient>();

            var result = new GetOutstandingByBetTimeResult(
                Success: true,
                Transactions: new GetOutstandingByBetTimeTransaction[] {
                    new GetOutstandingByBetTimeTransaction(){
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
                });
            _ = fakeClient.GetOutstandingByBetTimeAsync(
                Arg.Is(apiUrl),
                Arg.Is(agentId),
                Arg.Is(cert),
                Arg.Is(platform),
                Arg.Is(startTime),
                Arg.Is(endTime)).Returns(ValueTask.FromResult(result));

            var service = new GameUnsettleTransactionGetService(fakeClient);

            var actual = await service.QueryAsync(query).ToArrayAsync().ConfigureAwait(false);

            Assert.IsNotNull(actual);
            Assert.AreEqual($"{platform}-{result.Transactions!.First().PlatformTxId}", actual.First().ExternalRoundId);
            Assert.AreEqual(platform, actual.First().Platform);
        }
    }
}
