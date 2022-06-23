using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest
{
    [TestClass]
    public class FundInGetServiceUnitTest
    {
        [TestMethod]
        public async Task Normal_Process()
        {
            var apiUrl = new Uri("http://localhost/");
            var agentId = "testagentid";
            var cert = "testcert";
            var playerCode = "4ucmqplxb029";
            string transactionId = Guid.NewGuid().ToString("N");
            decimal amount = 100m;

            var query = new FundInQuery(
                ApiUrl: apiUrl,
                AgentId: agentId,
                Cert: cert,
                PlayerCode: playerCode,
                TransactionId: transactionId,
                Amount: amount);

            var fakeClient = Substitute.For<IGameApiClient>();

            var result = new FundResult(
                Success: true,
                TransactionId: transactionId,
                GameProviderTransactionId: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(),
                Amount: amount,
                CurrentBalance: 0);
            _ = fakeClient.WithdrawAsync(
                Arg.Is(apiUrl),
                Arg.Is(agentId),
                Arg.Is(cert),
                Arg.Is(playerCode),
                Arg.Is(transactionId),
                Arg.Is(amount)).Returns(ValueTask.FromResult(result));

            var service = new FundInGetService(fakeClient);

            var actual = await service.GetAsync(query).ConfigureAwait(false);

            Assert.IsTrue(actual.Success);
            Assert.AreEqual(result.TransactionId, actual.TransactionId);
            Assert.AreEqual(result.GameProviderTransactionId, actual.GameProviderTransactionId);
            Assert.AreEqual(result.CurrentBalance, actual.CurrentBalance);
        }
    }
}
