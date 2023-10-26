namespace Tgs.GameInterface.AwcService.Core.Models;

public record GetBalanceResp(
    bool IsPlayerExist,
    decimal Balance);
