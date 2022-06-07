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
    public class FundOrderCheckingUnitTest
    {
        [TestMethod]
        public async Task Normal_Process()
        {
            var apiUrl = new Uri("http://localhost/");
            var agentId = "testagentid";
            var cert = "testcert";
            string txCode = Guid.NewGuid().ToString("N");

            var response = new
            {
                status = ((int)GameApiClientError.Success).ToString("d4"),
                desc = GameApiClientError.Success.ToString(),
                txStatus = 1,
                balance = 100,
                transferAmount = 100,
                transferType = "DEPOSIT",
                txCode
            };

            var content = JsonSerializer.Serialize(response);
            var handler = new MockHttpMessageHandler();
            _ = handler.Expect(HttpMethod.Post, "/wallet/checkTransferOperation")
            .Respond(HttpStatusCode.OK, new StringContent(content));

            var fakeHttpClient = handler.ToHttpClient();
            var fakeLog = NullLogger<GameApiClient>.Instance;
            var fakeTgsLog = Substitute.For<ITgsLog>();
            var client = new GameApiClient(fakeHttpClient, fakeLog, fakeTgsLog);

            var actual = await client.FundOrderCheckingAsync(apiUrl, agentId, cert, txCode);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public async Task Transfer_Fail()
        {
            var apiUrl = new Uri("http://localhost/");
            var agentId = "testagentid";
            var cert = "testcert";
            string txCode = Guid.NewGuid().ToString("N");

            var response = new
            {
                status = ((int)GameApiClientError.Success).ToString("d4"),
                desc = GameApiClientError.Success.ToString(),
                txStatus = 0,
                balance = 100,
                transferAmount = 100,
                transferType = "DEPOSIT",
                txCode
            };

            var content = JsonSerializer.Serialize(response);
            var handler = new MockHttpMessageHandler();
            _ = handler.Expect(HttpMethod.Post, "/wallet/checkTransferOperation")
            .Respond(HttpStatusCode.OK, new StringContent(content));

            var fakeHttpClient = handler.ToHttpClient();
            var fakeLog = NullLogger<GameApiClient>.Instance;
            var fakeTgsLog = Substitute.For<ITgsLog>();
            var client = new GameApiClient(fakeHttpClient, fakeLog, fakeTgsLog);

            var actual = await client.FundOrderCheckingAsync(apiUrl, agentId, cert, txCode);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public async Task Txcode_Is_Not_Exist()
        {
            var apiUrl = new Uri("http://localhost/");
            var agentId = "testagentid";
            var cert = "testcert";
            string txCode = Guid.NewGuid().ToString("N");

            var response = new
            {
                status = ((int)GameApiClientError.TxcodeIsNotExist).ToString("d4"),
                desc = GameApiClientError.TxcodeIsNotExist.ToString()
            };

            var content = JsonSerializer.Serialize(response);
            var handler = new MockHttpMessageHandler();
            _ = handler.Expect(HttpMethod.Post, "/wallet/checkTransferOperation")
            .Respond(HttpStatusCode.OK, new StringContent(content));

            var fakeHttpClient = handler.ToHttpClient();
            var fakeLog = NullLogger<GameApiClient>.Instance;
            var fakeTgsLog = Substitute.For<ITgsLog>();
            var client = new GameApiClient(fakeHttpClient, fakeLog, fakeTgsLog);

            _ = await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                _ = await client.FundOrderCheckingAsync(
                    apiUrl,
                    agentId,
                    cert,
                    txCode).AsTask().ConfigureAwait(false);
            });
        }
    }
}
