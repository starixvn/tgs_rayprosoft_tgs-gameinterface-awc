using System;
using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using RichardSzalay.MockHttp;
using Tgs.GameInterface.Awc.Core;

namespace Tgs.GameInterface.Awc.Core.UnitTest;

public class FundOutUnitTest
{
    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        string txCode = "018b69f88cfa0000000107e72e647968";
        decimal amount = 25m;

        var response = new JsonObject
        {
            ["method"] = "DEPOSIT",
            ["databaseId"] = 1557023954,
            ["currentBalance"] = "25.51",
            ["lastModified"] = "2023-10-26T11:12:58.662+08:00",
            ["txCode"] = "018b69f88cfa0000000107e72e647968",
            ["amount"] = "25",
            ["status"] = "0000"
        };

        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/deposit")
        .Respond(HttpStatusCode.OK, new StringContent(response.ToJsonString()));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        var actual = await client.DepositAsync(apiUrl, agentId, cert, playerCode, txCode, amount);

        Assert.Equal("018b69f88cfa0000000107e72e647968", actual.TransactionId);
        Assert.Equal("1557023954", actual.GameProviderTransactionId);
        Assert.Equal(25m, actual.Amount);
        Assert.Equal(25.51m, actual.CurrentBalance);
        Assert.Equal(response.ToJsonString(), actual.Resp);
    }
}
