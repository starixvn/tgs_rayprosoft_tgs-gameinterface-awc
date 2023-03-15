using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;

namespace Tgs.GameInterface.AwcService.Core.UnitTest;

[TestClass]
public class CreatePlayerUnitTests
{
    [TestMethod]
    public async Task Account_Existed()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var userName = "4ucmqplxb029";
        var currencyCode = "HKD";
        var cultureCode = "cn";

        var response = new
        {
            status = ((int)GameApiClientError.AccountExisted).ToString("d4"),
            desc = GameApiClientError.AccountExisted.ToString()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/createMember")
            .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        await client.CreatePlayerAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            playerCode: playerCode,
            userName: userName,
            currency: currencyCode,
            language: cultureCode);
    }

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

        var response = new
        {
            status = ((int)GameApiClientError.Fail).ToString("d4"),
            desc = GameApiClientError.Fail.ToString()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/createMember")
                .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        _ = await Assert.ThrowsExceptionAsync<Exception>(() =>
        client.CreatePlayerAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            playerCode: playerCode,
            userName: userName,
            currency: currencyCode,
            language: cultureCode).AsTask()).ConfigureAwait(false);
    }

    [TestMethod]
    public async Task Normal_Process_Is_Live_HORSEBOOK()
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
            HORSEBOOK = new
            {
                LIVE = new
                {
                    minbet = 10,
                    maxbet = 3000,
                    maxBetSumPerHorse = 10000,
                    minorMinbet = 10,
                    minorMaxbet = 1000,
                    minorMaxBetSumPerHorse = 10000
                }
            }
        });

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/createMember")
                .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        await client.CreatePlayerAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            playerCode: playerCode,
            userName: userName,
            currency: currencyCode,
            betLimit: betLimit,
            language: cultureCode);
    }

    [TestMethod]
    public async Task Normal_Process_Is_Live_SEXYBCRT()
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
            SEXYBCRT = new
            {
                LIVE = new
                {
                    limitId = new[] { "280303", "280304", "280305" }
                }
            }
        });

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/createMember")
                .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        await client.CreatePlayerAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            playerCode: playerCode,
            userName: userName,
            currency: currencyCode,
            betLimit: betLimit,
            language: cultureCode);
    }

    [TestMethod]
    public async Task Normal_Process_Is_Live_SV388()
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
            SV388 = new
            {
                LIVE = new
                {
                    maxbet = 3000,
                    minbet = 1,
                    mindraw = 1,
                    matchlimit = 6000,
                    maxdraw = 900
                }
            }
        });

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/createMember")
                .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        await client.CreatePlayerAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            playerCode: playerCode,
            userName: userName,
            currency: currencyCode,
            betLimit: betLimit,
            language: cultureCode);
    }

    [TestMethod]
    public async Task Normal_Process_Is_Live_VENUS()
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

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/createMember")
                .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        await client.CreatePlayerAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            playerCode: playerCode,
            userName: userName,
            currency: currencyCode,
            betLimit: betLimit,
            language: cultureCode);
    }

    [TestMethod]
    public async Task Normal_Process_Not_Live()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var userName = "4ucmqplxb029";
        var currencyCode = "HKD";
        var cultureCode = "cn";

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/createMember")
                .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        await client.CreatePlayerAsync(
            apiUrl: apiUrl,
            agentId: agentId,
            cert: cert,
            playerCode: playerCode,
            userName: userName,
            currency: currencyCode,
            language: cultureCode);
    }
}
