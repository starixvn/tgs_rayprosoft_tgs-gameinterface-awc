using System;
using System.Text.Json;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest.ApplicationServices;

public class GameUrlLobbyByLiveGetServiceUnitTest
{
    [Fact]
    public async Task Account_Is_Not_Exists()
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

        var query = new GameUrlLobbyByLiveQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: AwcPlatforms.AWC_VENUS,
            ExternalGameId: "VN-LIVE-001",
            Language: cultureCode,
            BetLimit: betLimit);

        var fakeClient = Substitute.For<IGameApiClient>();

        var data = new LoginAndLaunchGameByLive(
            PlayerCode: query.PlayerCode,
            IsMobileLogin: query.IsMobileLogin,
            BackUrl: query.BackUrl,
            Platform: query.Platform,
            ExternalGameId: query.ExternalGameId,
            BetLimit: query.BetLimit,
            Language: query.Language);

        var result = new LoginAndLaunchGameResult(
            IsPlayerExist: false,
            GameUrl: string.Empty
            );

        _ = fakeClient.LoginAndLaunchGameAsync(
            apiUrl: Arg.Is(apiUrl),
            agentId: Arg.Is(agentId),
            cert: Arg.Is(cert),
            data: Arg.Is(data)).Returns(result);

        var service = new GameUrlLobbyByLiveGetService(fakeClient);

        var actual = await service.GetAsync(query);

        Assert.False(actual.IsPlayerExist);
    }

    [Fact]
    public async Task Exception_Process()
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

        var query = new GameUrlLobbyByLiveQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: AwcPlatforms.AWC_VENUS,
            ExternalGameId: "VN-LIVE-001",
            Language: cultureCode,
            BetLimit: betLimit);

        var fakeClient = Substitute.For<IGameApiClient>();

        var data = new LoginAndLaunchGameByLive(
            PlayerCode: query.PlayerCode,
            IsMobileLogin: query.IsMobileLogin,
            BackUrl: query.BackUrl,
            Platform: query.Platform,
            ExternalGameId: query.ExternalGameId,
            BetLimit: query.BetLimit,
            Language: query.Language);

        _ = fakeClient.LoginAndLaunchGameAsync(
            apiUrl: Arg.Is(apiUrl),
            agentId: Arg.Is(agentId),
            cert: Arg.Is(cert),
            data: Arg.Is(data)).Throws<Exception>();

        var service = new GameUrlLobbyByLiveGetService(fakeClient);

        _ = await Assert.ThrowsAsync<Exception>(() => service.GetAsync(query).AsTask());
    }

    [Fact]
    public async Task Normal_Process()
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

        var query = new GameUrlLobbyByLiveQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: AwcPlatforms.AWC_VENUS,
            ExternalGameId: "VN-LIVE-001",
            Language: cultureCode,
            BetLimit: betLimit);

        var fakeClient = Substitute.For<IGameApiClient>();

        var data = new LoginAndLaunchGameByLive(
            PlayerCode: query.PlayerCode,
            IsMobileLogin: query.IsMobileLogin,
            BackUrl: query.BackUrl,
            Platform: query.Platform,
            ExternalGameId: query.ExternalGameId,
            BetLimit: query.BetLimit,
            Language: query.Language);

        var result = new LoginAndLaunchGameResult(
            IsPlayerExist: true,
            GameUrl: "http://localhost");

        _ = fakeClient.LoginAndLaunchGameAsync(
            apiUrl: Arg.Is(apiUrl),
            agentId: Arg.Is(agentId),
            cert: Arg.Is(cert),
            data: Arg.Is(data)).Returns(result);

        var service = new GameUrlLobbyByLiveGetService(fakeClient);

        var actual = await service.GetAsync(query);

        Assert.True(actual.IsPlayerExist);
        Assert.Equal(result.GameUrl, actual.GameUrl);
    }
}
