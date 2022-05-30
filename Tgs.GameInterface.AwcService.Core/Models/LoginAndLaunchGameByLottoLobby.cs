namespace Tgs.GameInterface.AwcService.Core.Models
{
    public record LoginAndLaunchGameByLottoLobby(
          string PlayerCode,
          bool IsMobileLogin,
          string ExternalURL,
          string Platform,
          string Language = "en");
}
