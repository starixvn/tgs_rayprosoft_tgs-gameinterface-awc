using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;

namespace Tgs.GameInterface.AwcService.Core.UnitTest
{
    [TestClass]
    public class CreatePlayerByBetLimitCommandServiceUnitTest
    {
        [TestMethod]
        public async Task Failed_To_Create_Member()
        {
            var apiUrl = new Uri("http://localhost/");
            var agentId = "testagentid";
            var cert = "testcert";
            var playerCode = "4ucmqplxb029";
            var userName = "4ucmqplxb029";
            var currencyCode = "HKD";
            var cultureCode = "cn";
            var betLimit = JsonSerializer.Serialize(new
            {
                VENUS = new
                {
                    LIVE = new
                    {
                        limitId = new[] { "280303", "280304", "280305" }
                    }
                }
            });

            var query = new CreatePlayerByBetLimitCommand(
                ApiUrl: apiUrl,
                AgentId: agentId,
                Cert: cert,
                PlayerCode: playerCode,
                UserName: userName,
                Currency: currencyCode,
                BetLimit: betLimit,
                Language: cultureCode);

            var fakeClient = Substitute.For<IGameApiClient>();

            _ = fakeClient.CreatePlayerAsync(
                apiUrl: Arg.Is(apiUrl),
                agentId: Arg.Is(agentId),
                cert: Arg.Is(cert),
                playerCode: Arg.Is(playerCode),
                userName: Arg.Is(userName),
                currency: Arg.Is(currencyCode),
                betLimit: Arg.Is(betLimit),
                language: Arg.Is(cultureCode)).Throws<Exception>();

            var service = new CreatePlayerByBetLimitCommandService(fakeClient);

            _ = await Assert.ThrowsExceptionAsync<Exception>(() => service.ExecuteAsync(query).AsTask()).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task Normal_Process()
        {
            var apiUrl = new Uri("http://localhost/");
            var agentId = "testagentid";
            var cert = "testcert";
            var playerCode = "4ucmqplxb029";
            var userName = "4ucmqplxb029";
            var currencyCode = "HKD";
            var cultureCode = "cn";
            var betLimit = JsonSerializer.Serialize(new
            {
                VENUS = new
                {
                    LIVE = new
                    {
                        limitId = new[] { "280303", "280304", "280305" }
                    }
                }
            });

            var query = new CreatePlayerByBetLimitCommand(
                ApiUrl: apiUrl,
                AgentId: agentId,
                Cert: cert,
                PlayerCode: playerCode,
                UserName: userName,
                Currency: currencyCode,
                BetLimit: betLimit,
                Language: cultureCode);

            var fakeClient = Substitute.For<IGameApiClient>();

            _ = fakeClient.CreatePlayerAsync(
                apiUrl: Arg.Is(apiUrl),
                agentId: Arg.Is(agentId),
                cert: Arg.Is(cert),
                playerCode: Arg.Is(playerCode),
                userName: Arg.Is(userName),
                currency: Arg.Is(currencyCode),
                betLimit: Arg.Is(betLimit),
                language: Arg.Is(cultureCode));

            var service = new CreatePlayerByBetLimitCommandService(fakeClient);

            await service.ExecuteAsync(query).ConfigureAwait(false);
        }
    }
}
