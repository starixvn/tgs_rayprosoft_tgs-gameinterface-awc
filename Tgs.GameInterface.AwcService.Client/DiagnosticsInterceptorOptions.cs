using System.Diagnostics;

namespace Tgs.GameInterface.AwcService.Client
{
    public class DiagnosticsInterceptorOptions
    {
        public ActivitySource InterceptorActivitySource { get; set; } =
            new ActivitySource($"Tgs.GameInterface.AwcService.Client.DiagnosticsInterceptor");
    }
}
