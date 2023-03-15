using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;
using Tgs.GameInterface.AwcService.Core.Models;

namespace Tgs.GameInterface.AwcService.Core.UnitTest.ApplicationServices;

[TestClass]
public class AllBalanceQueryServiceUnitTest
{
    [TestMethod]
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

        var balances = new AllBalance[]
        {
            new AllBalance(
                UserId: "4udw90nrgp5f",
                Balance: 6541m,
                LastModified: DateTime.UtcNow)
        };
        _ = fakeClient.GetAllBalancesAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert)).Returns(balances.ToAsyncEnumerable());

        var service = new AllBalanceQueryService(fakeClient);

        var actual = await service
            .QueryAsync(
                query)
            .ToArrayAsync()
            .ConfigureAwait(false);

        Assert.IsNotNull(actual);
        Assert.IsTrue(actual.Any());
    }
}
