using System;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;

namespace Tgs.GameInterface.AwcService.Core.UnitTest.ApplicationServices;

public class PlayerCreateCommandServiceUnitTest
{
    [Fact]
    public async Task Failed_To_Create_Member()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var userName = "4ucmqplxb029";
        var currencyCode = "HKD";
        var cultureCode = "cn";

        var query = new PlayerCreateCommand(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            UserName: userName,
            Currency: currencyCode,
            Language: cultureCode);

        var fakeClient = Substitute.For<IGameApiClient>();

        _ = fakeClient.CreatePlayerAsync(
            apiUrl: Arg.Is(apiUrl),
            agentId: Arg.Is(agentId),
            cert: Arg.Is(cert),
            playerCode: Arg.Is(playerCode),
            userName: Arg.Is(userName),
            currency: Arg.Is(currencyCode),
            language: Arg.Is(cultureCode)).Throws<Exception>();

        var service = new PlayerCreateCommandService(fakeClient);

        _ = await Assert.ThrowsAsync<Exception>(() => service.ExecuteAsync(query).AsTask());
    }

    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var userName = "4ucmqplxb029";
        var currencyCode = "HKD";
        var cultureCode = "cn";

        var query = new PlayerCreateCommand(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            UserName: userName,
            Currency: currencyCode,
            Language: cultureCode);

        var fakeClient = Substitute.For<IGameApiClient>();

        _ = fakeClient.CreatePlayerAsync(
            apiUrl: Arg.Is(apiUrl),
            agentId: Arg.Is(agentId),
            cert: Arg.Is(cert),
            playerCode: Arg.Is(playerCode),
            userName: Arg.Is(userName),
            currency: Arg.Is(currencyCode),
            language: Arg.Is(cultureCode));

        var service = new PlayerCreateCommandService(fakeClient);

        await service.ExecuteAsync(query);
    }
}
