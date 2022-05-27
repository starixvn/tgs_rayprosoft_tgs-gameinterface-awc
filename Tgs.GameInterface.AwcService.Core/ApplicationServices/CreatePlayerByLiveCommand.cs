using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgs.GameInterface.AwcService.Core.ApplicationServices
{
    public record CreatePlayerByLiveCommand(
        Uri ApiUrl,
        string AgentId,
        string Cert,
        string PlayerCode,
        string UserName,
        string Currency,
        string BetLimit,
        string Language = "en");
}
