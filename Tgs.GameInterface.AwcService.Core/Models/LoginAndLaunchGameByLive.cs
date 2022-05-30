namespace Tgs.GameInterface.AwcService.Core.Models
{
    public record LoginAndLaunchGameByLive(
          string PlayerCode,
          bool IsMobileLogin,
          string ExternalURL,
          string Platform,
          string ExternalGameId,
          string BetLimit,
          string Language = "en");
}
