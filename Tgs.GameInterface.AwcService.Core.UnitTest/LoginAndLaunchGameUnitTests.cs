using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using RichardSzalay.MockHttp;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest;

public class LoginAndLaunchGameUnitTests
{
    [Fact]
    public async Task Account_Is_Not_Exists()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var cultureCode = "cn";

        var request = new LoginAndLaunchGame(
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: "YL",
            GameType: "FH",
            ExternalGameId: "YL-FISH-001",
            Language: cultureCode);

        var response = new
        {
            status = ((int)GameApiClientError.AccountIsNotExists).ToString("d4"),
            desc = GameApiClientError.AccountIsNotExists.ToString()
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/doLoginAndLaunchGame")
            .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        var result = await client.LoginAndLaunchGameAsync(apiUrl, agentId, cert, request);

        Assert.False(result.IsPlayerExist);
    }

    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var cultureCode = "cn";

        var request = new LoginAndLaunchGame(
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: "YL",
            GameType: "FH",
            ExternalGameId: "YL-FISH-001",
            Language: cultureCode);

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString(),
            url = "http://localhost"
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/doLoginAndLaunchGame")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        var result = await client.LoginAndLaunchGameAsync(apiUrl, agentId, cert, request);

        Assert.True(result.IsPlayerExist);
        Assert.Equal(response.url, result.GameUrl);
    }

    [Fact]
    public async Task Normal_Process_Is_Live_HORSEBOOK()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
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

        var request = new LoginAndLaunchGameByLive(
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: "HORSEBOOK",
            ExternalGameId: "HRB-LIVE-001",
            BetLimit: JsonSerializer.Serialize(betLimit),
            Language: cultureCode);

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString(),
            url = "http://localhost"
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/doLoginAndLaunchGame")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        var result = await client.LoginAndLaunchGameAsync(apiUrl, agentId, cert, request);

        Assert.True(result.IsPlayerExist);
        Assert.Equal(response.url, result.GameUrl);
    }

    [Fact]
    public async Task Normal_Process_Is_Live_SEXYBCRT()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var cultureCode = "cn";
        var betLimit = JsonSerializer.Serialize(new
        {
            SEXYBCRT = new
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

        var request = new LoginAndLaunchGameByLive(
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: "SEXYBCRT",
            ExternalGameId: "MX-LIVE-002",
            BetLimit: JsonSerializer.Serialize(betLimit),
            Language: cultureCode);

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString(),
            url = "http://localhost"
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/doLoginAndLaunchGame")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        var result = await client.LoginAndLaunchGameAsync(apiUrl, agentId, cert, request);

        Assert.True(result.IsPlayerExist);
        Assert.Equal(response.url, result.GameUrl);
    }

    [Fact]
    public async Task Normal_Process_Is_Live_SV388()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
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

        var request = new LoginAndLaunchGameByLive(
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: "SV388",
            ExternalGameId: "SV-LIVE-001",
            BetLimit: JsonSerializer.Serialize(betLimit),
            Language: cultureCode); ;

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString(),
            url = "http://localhost"
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/doLoginAndLaunchGame")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        var result = await client.LoginAndLaunchGameAsync(apiUrl, agentId, cert, request);

        Assert.True(result.IsPlayerExist);
        Assert.Equal(response.url, result.GameUrl);
    }

    [Fact]
    public async Task Normal_Process_Is_Live_VENUS()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
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

        var request = new LoginAndLaunchGameByLive(
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: "VENUS",
            ExternalGameId: "VN-LIVE-001",
            BetLimit: JsonSerializer.Serialize(betLimit),
            Language: cultureCode);

        var response = new
        {
            status = ((int)GameApiClientError.Success).ToString("d4"),
            desc = GameApiClientError.Success.ToString(),
            url = "http://localhost"
        };

        var content = JsonSerializer.Serialize(response);
        var handler = new MockHttpMessageHandler();
        _ = handler.Expect(HttpMethod.Post, "/wallet/doLoginAndLaunchGame")
        .Respond(HttpStatusCode.OK, new StringContent(content));

        var fakeHttpClient = handler.ToHttpClient();
        var fakeLog = NullLogger<GameApiClient>.Instance;
        var client = new GameApiClient(fakeLog, fakeHttpClient);

        var result = await client.LoginAndLaunchGameAsync(apiUrl, agentId, cert, request);

        Assert.True(result.IsPlayerExist);
        Assert.Equal(response.url, result.GameUrl);
    }
}
