using System;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using Tgs.GameInterface.Awc.Core.ApplicationServices;
using Tgs.GameInterface.Awc.Core.Models;

namespace Tgs.GameInterface.Awc.Core.UnitTest.ApplicationServices;

public class AllBalanceQueryServiceUnitTest
{
    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";

        var query = new AllBalanceQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert);

        var fakeClient = Substitute.For<IGameApiClient>();

        var balances = new BalanceInfo[]
        {
            new(
                UserId: "4udw90nrgp5f",
                Balance: 6541m,
                LastModified: DateTime.UtcNow)
        };
        _ = fakeClient.GetAllBalancesAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert)).Returns(balances.ToAsyncEnumerable());

        var service = new AllBalanceQueryService(fakeClient);

        var actual = await service.QueryAsync(
            query: query)
            .ToArrayAsync()
            ?? Enumerable.Empty<AllBalanceResult>();

        Assert.NotNull(actual);
        Assert.True(actual.Any());
    }
}
