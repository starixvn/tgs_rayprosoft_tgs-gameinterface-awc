using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using RichardSzalay.MockHttp;

namespace Tgs.GameInterface.AwcService.Core.UnitTest;

public class GetBalanceUnitTest
{
    [Fact]
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
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        var result = await client.GetBalanceAsync(apiUrl, agentId, cert, playerCode);

        Assert.False(result.IsPlayerExist);
    }

    [Fact]
    public async Task The_result_is_an_empty_array()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";

        var response = new JsonObject
        {
            ["results"] = new JsonArray(),
            ["count"] = 0,
            ["querytime"] = "2023-10-27T16:38:24.593+08:00",
            ["status"] = ((int)GameApiClientError.Success).ToString("d4")
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/getBalance")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        var result = await client.GetBalanceAsync(apiUrl, agentId, cert, playerCode);

        Assert.False(result.IsPlayerExist);
    }

    [Fact]
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
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        var result = await client.GetBalanceAsync(apiUrl, agentId, cert, playerCode);

        Assert.True(result.IsPlayerExist);
        Assert.Equal(decimal.Parse(response.results.First().balance), result.Balance);
    }
}
