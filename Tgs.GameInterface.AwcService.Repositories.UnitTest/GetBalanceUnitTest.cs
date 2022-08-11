using System;
using System.Linq;
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

namespace Tgs.GameInterface.AwcService.Repositories.UnitTest;

[TestClass]
public class GetBalanceUnitTest
{
    [TestMethod]
    public async Task Account_Is_Not_Exists()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";

        var response = new
        {
            status = ((int)GameApiClientError.AccountIsNotExists).ToString("d4"),
            desc = GameApiClientError.AccountIsNotExists.ToString()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/getBalance")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var fakeTgsLog = Substitute.For<ITgsLog>();
        var client = new GameApiClient(fakeHttpClient, fakeLog, fakeTgsLog);

        var result = await client.GetBalanceAsync(apiUrl, agentId, cert, playerCode);

        Assert.IsTrue(result.Success);
        Assert.IsFalse(result.IsPlayerExist);
        Assert.IsNull(result.Balance);
    }

    [TestMethod]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString(),
            results = new[]
            {
                new
                {
                    userId = playerCode,
                    lastModified = DateTime.UtcNow,
                    balance = "100"
                }
            }
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/getBalance")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var fakeTgsLog = Substitute.For<ITgsLog>();
        var client = new GameApiClient(fakeHttpClient, fakeLog, fakeTgsLog);

        var result = await client.GetBalanceAsync(apiUrl, agentId, cert, playerCode);

        Assert.IsTrue(result.Success);
        Assert.IsTrue(result.IsPlayerExist);
        Assert.AreEqual(decimal.Parse(response.results.First().balance), result.Balance);
    }
}
