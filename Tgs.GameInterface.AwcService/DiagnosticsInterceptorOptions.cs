using System.Diagnostics;

namespace Tgs.GameInterface.AwcService
{
    public class DiagnosticsInterceptorOptions
    {
        public ActivitySource InterceptorActivitySource { get; set; } =
            new ActivitySource($"Tgs.GameInterface.AwcService.DiagnosticsInterceptor");
    }
}
