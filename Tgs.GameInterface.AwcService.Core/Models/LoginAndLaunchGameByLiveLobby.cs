namespace Tgs.GameInterface.AwcService.Core.Models
{
    public record LoginAndLaunchGameByLiveLobby(
          string PlayerCode,
          bool IsMobileLogin,
          string ExternalURL,
          string Platform,
          string BetLimit,
          string Language = "en");
}
