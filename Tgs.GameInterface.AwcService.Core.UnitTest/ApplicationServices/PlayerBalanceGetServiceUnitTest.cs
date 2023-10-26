using System;
using System.Threading.Tasks;
using NSubstitute;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest.ApplicationServices;

public class PlayerBalanceGetServiceUnitTest
{
    [Fact]
    public async Task Account_Is_Not_Exists()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";

        var query = new PlayerBalanceQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode);

        var fakeClient = Substitute.For<IGameApiClient>();

        var result = new GetBalanceResp(
            IsPlayerExist: false,
            Balance: 0.0m);
        _ = fakeClient.GetBalanceAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(playerCode)).Returns(ValueTask.FromResult(result));

        var service = new PlayerBalanceGetService(fakeClient);

        var actual = await service.GetAsync(query);

        Assert.False(actual.IsPlayerExist);
    }

    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";

        var query = new PlayerBalanceQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode);

        var fakeClient = Substitute.For<IGameApiClient>();

        var result = new GetBalanceResp(
            IsPlayerExist: true,
            Balance: 100m);
        _ = fakeClient.GetBalanceAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(playerCode)).Returns(ValueTask.FromResult(result));

        var service = new PlayerBalanceGetService(fakeClient);

        var actual = await service.GetAsync(query);

        Assert.True(actual.IsPlayerExist);
        Assert.Equal(result.Balance, actual.Balance);
    }
}
