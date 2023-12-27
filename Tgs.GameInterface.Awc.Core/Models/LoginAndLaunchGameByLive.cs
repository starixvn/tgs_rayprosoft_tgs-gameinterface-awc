namespace Tgs.GameInterface.Awc.Core.Models;

public record LoginAndLaunchGameByLive(
      string PlayerCode,
      bool IsMobileLogin,
      string BackUrl,
      string Platform,
      string ExternalGameId,
      string BetLimit,
      string Language = "en");
