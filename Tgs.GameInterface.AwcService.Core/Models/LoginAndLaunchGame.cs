namespace Tgs.GameInterface.AwcService.Core.Models
{
    public record LoginAndLaunchGame(
         string PlayerCode,
         bool IsMobileLogin,
         string ExternalURL,
         string Platform,
         string GameType,
         string ExternalGameId,
         string Language);
}
