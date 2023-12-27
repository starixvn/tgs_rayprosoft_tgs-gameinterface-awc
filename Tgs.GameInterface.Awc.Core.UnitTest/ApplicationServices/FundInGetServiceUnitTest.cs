using System;
using System.Threading.Tasks;
using NSubstitute;
using Tgs.GameInterface.Awc.Core.ApplicationServices;

namespace Tgs.GameInterface.Awc.Core.UnitTest.ApplicationServices;

public class FundInGetServiceUnitTest
{
    [Fact]
    public async Task Normal_Process()
    {
        var apiUrl = new Uri("http://localhost/");
        var agentId = "testagentid";
        var cert = "testcert";
        var playerCode = "4ucmqplxb029";
        var orderId = "018b69d42cef0000000107e7cfe506aa";
        var amount = 16000m;

        var query = new FundInQuery(
            ApiUrl: apiUrl,
            AgentId: agentId,
            Cert: cert,
            PlayerCode: playerCode,
            OrderId: orderId,
            Amount: amount);

        var fakeClient = Substitute.For<IGameApiClient>();

        var result = new Models.FundResp(
            TransactionId: "018b69d42cef0000000107e7cfe506aa",
            GameProviderTransactionId: "1556992469",
            Amount: 16000m,
            CurrentBalance: 0.35m,
            Resp: "{\"method\":\"WITHDRAW\",\"databaseId\":1556992469,\"currentBalance\":\"0.35\",\"lastModified\":\"2023-10-26T10:33:14.763+08:00\",\"txCode\":\"018b69d42cef0000000107e7cfe506aa\",\"amount\":\"16000\",\"status\":\"0000\"}");
        _ = fakeClient.WithdrawAsync(
            Arg.Is(apiUrl),
            Arg.Is(agentId),
            Arg.Is(cert),
            Arg.Is(playerCode),
            Arg.Is(orderId),
            Arg.Is(amount)).Returns(ValueTask.FromResult(result));

        var service = new FundInGetService(fakeClient);

        var actual = await service.GetAsync(query);

        Assert.Equal("018b69d42cef0000000107e7cfe506aa", actual.OrderId);
        Assert.Equal("1556992469", actual.GameProviderTransactionId);
        Assert.Equal(16000m, actual.Amount);
        Assert.Equal(0.35m, actual.CurrentBalance);
        Assert.Equal(result.Resp, actual.Resp);
    }
}
