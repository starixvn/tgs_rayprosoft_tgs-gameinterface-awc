using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest;

[TestClass]
public class GameUrlGetServiceUnitTest
{
    [TestMethod]
    public async Task Account_Is_Not_Exists()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var cultureCode = "cn";

        var query = new GameUrlQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: "YL",
            ExternalGameId: "YL-FISH-001",
            Language: cultureCode);

        var fakeClient = Substitute.For<IGameApiClient>();

        var data = new LoginAndLaunchGame(
            PlayerCode: query.PlayerCode,
            IsMobileLogin: query.IsMobileLogin,
            BackUrl: query.BackUrl,
            Platform: query.Platform,
            GameType: "FH",
            ExternalGameId: query.ExternalGameId,
            Language: query.Language);

        var result = new LoginAndLaunchGameResult(
            Success: true,
            IsPlayerExist: false,
            GameUrl: null
            );

        _ = fakeClient.LoginAndLaunchGameAsync(
            apiUrl: Arg.Is(apiUrl),
            agentId: Arg.Is(agentId),
            cert: Arg.Is(cert),
            data: Arg.Is(data)).Returns(result);

        var service = new GameUrlGetService(fakeClient);

        var actual = await service.GetAsync(query).ConfigureAwait(false);

        Assert.IsTrue(actual.Success);
        Assert.IsFalse(actual.IsPlayerExist);
        Assert.IsNull(actual.GameUrl);
    }

    [TestMethod]
    public async Task Exception_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var cultureCode = "cn";

        var query = new GameUrlQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: "YL",
            ExternalGameId: "YL-FISH-001",
            Language: cultureCode);

        var fakeClient = Substitute.For<IGameApiClient>();

        var data = new LoginAndLaunchGame(
            PlayerCode: query.PlayerCode,
            IsMobileLogin: query.IsMobileLogin,
            BackUrl: query.BackUrl,
            Platform: query.Platform,
            GameType: "FH",
            ExternalGameId: query.ExternalGameId,
            Language: query.Language);

        _ = fakeClient.LoginAndLaunchGameAsync(
            apiUrl: Arg.Is(apiUrl),
            agentId: Arg.Is(agentId),
            cert: Arg.Is(cert),
            data: Arg.Is(data)).Throws<Exception>();

        var service = new GameUrlGetService(fakeClient);

        _ = await Assert.ThrowsExceptionAsync<Exception>(() => service.GetAsync(query).AsTask()).ConfigureAwait(false);
    }

    [TestMethod]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var cultureCode = "cn";

        var query = new GameUrlQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            IsMobileLogin: false,
            BackUrl: "https://dev-t1.rpgp.cc/zh-CN",
            Platform: "YL",
            ExternalGameId: "YL-FISH-001",
            Language: cultureCode);

        var fakeClient = Substitute.For<IGameApiClient>();

        var data = new LoginAndLaunchGame(
            PlayerCode: query.PlayerCode,
            IsMobileLogin: query.IsMobileLogin,
            BackUrl: query.BackUrl,
            Platform: query.Platform,
            GameType: "FH",
            ExternalGameId: query.ExternalGameId,
            Language: query.Language);

        var result = new LoginAndLaunchGameResult(
            Success: true,
            IsPlayerExist: true,
            GameUrl: "http://localhost"
            );

        _ = fakeClient.LoginAndLaunchGameAsync(
            apiUrl: Arg.Is(apiUrl),
            agentId: Arg.Is(agentId),
            cert: Arg.Is(cert),
            data: Arg.Is(data)).Returns(result);

        var service = new GameUrlGetService(fakeClient);

        var actual = await service.GetAsync(query).ConfigureAwait(false);

        Assert.IsTrue(actual.Success);
        Assert.IsTrue(actual.IsPlayerExist);
        Assert.AreEqual(result.GameUrl, actual.GameUrl);
    }
}
