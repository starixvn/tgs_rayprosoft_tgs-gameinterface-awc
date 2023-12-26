using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using RichardSzalay.MockHttp;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest;

public class GetAllBalanceUnitTest
{
    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("https://tttint.onlinegames22.com/");
        var agentId = "cnygpiawsslot";
        var cert = "ohh3uhFCoeFA66US28G";

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString(),
            results = new[]
            {
                new
                {
                    userId="4udw90nrgp5f",
                    balance = "6541",
                    lastModified = DateTime.UtcNow
                },
                new
                {
                    userId="4ugsfzzte82j",
                    balance = "0.6",
                    lastModified = DateTime.UtcNow
                },
                new
                {
                    userId="4uhgb0wa6kev",
                    balance = "0.5",
                    lastModified = DateTime.UtcNow
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

        var result = await client.GetAllBalancesAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert)
            .ToArrayAsync()
            ?? Enumerable.Empty<BalanceInfo>();

        Assert.NotNull(result);
        Assert.True(result.Any());
    }
}
