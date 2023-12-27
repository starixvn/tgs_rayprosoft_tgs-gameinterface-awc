namespace Tgs.GameInterface.Awc.Core.Models;

public record GetBalanceResp(
    bool IsPlayerExist,
    decimal Balance);
