using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RichardSzalay.MockHttp;
using Tgs.GameInterface.AwcService.Core;
using Tgs.Logging;

namespace Tgs.GameInterface.AwcService.Repositories.UnitTest
{
    [TestClass]
    public class FundOutUnitTest
    {
        [TestMethod]
        public async Task Normal_Process()
        {
            var apiUrl = new Uri("http://localhost/");
            var agentId = "testagentid";
            var cert = "testcert";
            var playerCode = "4ucmqplxb029";
            string txCode = Guid.NewGuid().ToString("N");
            decimal amount = 100m;

            var response = new
            {
                status = ((int)GameApiClientError.Success).ToString("d4"),
                desc = GameApiClientError.Success.ToString(),
                amount = amount.ToString(),
                method = "DEPOSIT",
                databaseId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(),
                currentBalance = "100",
                lastModified = DateTime.UtcNow,
                txCode
            };

            var content = JsonSerializer.Serialize(response);
            var handler = new MockHttpMessageHandler();
            _ = handler.Expect(HttpMethod.Post, "/wallet/deposit")
            .Respond(HttpStatusCode.OK, new StringContent(content));

            var fakeHttpClient = handler.ToHttpClient();
            var fakeLog = NullLogger<GameApiClient>.Instance;
            var fakeTgsLog = Substitute.For<ITgsLog>();
            var client = new GameApiClient(fakeHttpClient, fakeLog, fakeTgsLog);

            var actual = await client.FundOutAsync(apiUrl, agentId, cert, playerCode, txCode, amount);

            Assert.IsTrue(actual.Success);
            Assert.AreEqual(response.txCode, actual.TransactionId);
            Assert.AreEqual(response.databaseId, actual.GameProductTransactionId);
            Assert.AreEqual(decimal.Parse(response.amount), actual.Amount);
            Assert.AreEqual(decimal.Parse(response.currentBalance), actual.CurrentBalance);
        }
    }
}
