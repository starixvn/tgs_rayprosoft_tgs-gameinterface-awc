using System;
using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using RichardSzalay.MockHttp;

namespace Tgs.GameInterface.AwcService.Core.UnitTest;

public class FundInUnitTest
{
    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        string transactionId = "018b69d42cef0000000107e7cfe506aa";
        decimal amount = 16000m;

        var response = new JsonObject
        {
            ["method"] = "WITHDRAW",
            ["databaseId"] = 1556992469,
            ["currentBalance"] = "0.35",
            ["lastModified"] = "2023-10-26T10:33:14.763+08:00",
            ["txCode"] = "018b69d42cef0000000107e7cfe506aa",
            ["amount"] = "16000",
            ["status"] = "0000"
        };

        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/withdraw")
        .Respond(HttpStatusCode.OK, new StringContent(response.ToJsonString()));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        var actual = await client.WithdrawAsync(apiUrl, agentId, cert, playerCode, transactionId, amount);

        Assert.Equal("018b69d42cef0000000107e7cfe506aa", actual.TransactionId);
        Assert.Equal("1556992469", actual.GameProviderTransactionId);
        Assert.Equal(16000m, actual.Amount);
        Assert.Equal(0.35m, actual.CurrentBalance);
        Assert.Equal(response.ToJsonString(), actual.Resp);
    }
}
