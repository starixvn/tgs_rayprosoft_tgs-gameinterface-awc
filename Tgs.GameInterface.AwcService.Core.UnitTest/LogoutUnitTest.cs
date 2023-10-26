using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using RichardSzalay.MockHttp;

namespace Tgs.GameInterface.AwcService.Core.UnitTest;

public class LogoutUnitTest
{
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
            logoutUsers = new[] { playerCode }
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/logout")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        await client.LogoutAsync(apiUrl, agentId, cert, playerCode);
    }
}
