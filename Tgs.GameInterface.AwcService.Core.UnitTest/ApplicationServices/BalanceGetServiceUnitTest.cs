using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest.ApplicationServices;

[TestClass]
public class BalanceGetServiceUnitTest
{
    [TestMethod]
    public async Task Account_Is_Not_Exists()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";

        var query = new BalanceQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode);

        var fakeClient = Substitute.For<IGameApiClient>();

        var result = new GetBalanceResult(
            Success: true,
            IsPlayerExist: false,
            Balance: null);
        _ = fakeClient.GetBalanceAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(playerCode)).Returns(ValueTask.FromResult(result));

        var service = new BalanceGetService(fakeClient);

        var actual = await service.GetAsync(query).ConfigureAwait(false);

        Assert.IsTrue(actual.Success);
        Assert.IsFalse(actual.IsPlayerExist);
        Assert.IsNull(actual.Balance);
    }

    [TestMethod]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";

        var query = new BalanceQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode);

        var fakeClient = Substitute.For<IGameApiClient>();

        var result = new GetBalanceResult(
            Success: true,
            IsPlayerExist: true,
            Balance: 100m);
        _ = fakeClient.GetBalanceAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(playerCode)).Returns(ValueTask.FromResult(result));

        var service = new BalanceGetService(fakeClient);

        var actual = await service.GetAsync(query).ConfigureAwait(false);

        Assert.IsTrue(actual.Success);
        Assert.IsTrue(actual.IsPlayerExist);
        Assert.AreEqual(result.Balance, actual.Balance);
    }
}
