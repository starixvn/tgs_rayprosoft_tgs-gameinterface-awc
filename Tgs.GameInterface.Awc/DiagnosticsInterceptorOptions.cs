using System.Diagnostics;

namespace Tgs.GameInterface.Awc;

public class DiagnosticsInterceptorOptions
{
    public ActivitySource InterceptorActivitySource { get; set; } =
        new ActivitySource($"Tgs.GameInterface.Awc.DiagnosticsInterceptor");
}
