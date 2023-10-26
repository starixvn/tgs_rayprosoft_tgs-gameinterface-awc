using System;
using System.Threading.Tasks;
using NSubstitute;
using Tgs.GameInterface.AwcService.Core.ApplicationServices;

namespace Tgs.GameInterface.AwcService.Core.UnitTest.ApplicationServices;

public class FundOutGetServiceUnitTest
{
    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var orderId = "018b69f88cfa0000000107e72e647968";
        var amount = 25m;

        var query = new FundOutQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            OrderId: orderId,
            Amount: amount);

        var fakeClient = Substitute.For<IGameApiClient>();

        var result = new Models.FundResp(
            TransactionId: "018b69f88cfa0000000107e72e647968",
            GameProviderTransactionId: "1557023954",
            Amount: 25m,
            CurrentBalance: 25.51m,
            Resp: "{\"method\":\"DEPOSIT\",\"databaseId\":1557023954,\"currentBalance\":\"25.51\",\"lastModified\":\"2023-10-26T11:12:58.662+08:00\",\"txCode\":\"018b69f88cfa0000000107e72e647968\",\"amount\":\"25\",\"status\":\"0000\"}");
        _ = fakeClient.DepositAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(playerCode),
            Arg.Is(orderId),
            Arg.Is(amount)).Returns(ValueTask.FromResult(result));

        var service = new FundOutGetService(fakeClient);

        var actual = await service.GetAsync(query);

        Assert.Equal("018b69f88cfa0000000107e72e647968", actual.OrderId);
        Assert.Equal("1557023954", actual.GameProviderTransactionId);
        Assert.Equal(25m, actual.Amount);
        Assert.Equal(25.51m, actual.CurrentBalance);
        Assert.Equal(result.Resp, actual.Resp);
    }
}
