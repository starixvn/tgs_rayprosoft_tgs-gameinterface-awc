using System;
using System.Text.Json;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Tgs.GameInterface.Awc.Core.ApplicationServices;

namespace Tgs.GameInterface.Awc.Core.UnitTest.ApplicationServices;

public class PlayerCreateByBetLimitCommandServiceUnitTest
{
    private static readonly string[] _Value = ["280303", "280304", "280305"];
    private static readonly string[] _ValueArray = ["280303", "280304", "280305"];

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
        var betLimit = JsonSerializer.Serialize(new
        {
            VENUS = new
            {
                LIVE = new
                {
                    limitId = _Value
                }
            }
        });

        var query = new PlayerCreateByBetLimitCommand(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            UserName: userName,
            Currency: currencyCode,
            BetLimit: betLimit,
            Language: cultureCode);

        var fakeClient = Substitute.For<IGameApiClient>();

        _ = fakeClient.CreatePlayerAsync(
            apiUrl: Arg.Is(apiUrl),
            agentId: Arg.Is(agentId),
            cert: Arg.Is(cert),
            playerCode: Arg.Is(playerCode),
            userName: Arg.Is(userName),
            currency: Arg.Is(currencyCode),
            betLimit: Arg.Is(betLimit),
            language: Arg.Is(cultureCode)).Throws<Exception>();

        var service = new PlayerCreateByBetLimitCommandService(fakeClient);

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
        var betLimit = JsonSerializer.Serialize(new
        {
            VENUS = new
            {
                LIVE = new
                {
                    limitId = _ValueArray
                }
            }
        });

        var query = new PlayerCreateByBetLimitCommand(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            UserName: userName,
            Currency: currencyCode,
            BetLimit: betLimit,
            Language: cultureCode);

        var fakeClient = Substitute.For<IGameApiClient>();

        _ = fakeClient.CreatePlayerAsync(
            apiUrl: Arg.Is(apiUrl),
            agentId: Arg.Is(agentId),
            cert: Arg.Is(cert),
            playerCode: Arg.Is(playerCode),
            userName: Arg.Is(userName),
            currency: Arg.Is(currencyCode),
            betLimit: Arg.Is(betLimit),
            language: Arg.Is(cultureCode));

        var service = new PlayerCreateByBetLimitCommandService(fakeClient);

        await service.ExecuteAsync(query);
    }
}
