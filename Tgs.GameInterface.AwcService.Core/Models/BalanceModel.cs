namespace Tgs.GameInterface.AwcService.Core.Models;

public record BalanceModel
{
    public string UserId { get; set; } = default!;
    public string Balance { get; set; } = default!;
    public DateTime LastModified { get; set; }
}
