using Microsoft.Extensions.Options;
using Tgs.GameInterface.AwcService.Client;
using Tgs.GameInterface.AwcService.Protos;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGameInterfaceAwcServiceClient(
        this IServiceCollection services,
        Action<GameInterfaceAwcServiceClientOptions, IServiceProvider> configure)
        => services
            .AddOptions<GameInterfaceAwcServiceClientOptions>()
            .Configure(configure)
            .Services
            .AddGrpcClient<GameInterfaceAwcService.GameInterfaceAwcServiceClient>((sp, configureClient) =>
           {
               var options = sp.GetRequiredService<IOptions<GameInterfaceAwcServiceClientOptions>>().Value;
               configureClient.Address = options.BaseUrl;
           })
            .ConfigureChannel((sp, configureChannel) =>
            {
                var handler = new SocketsHttpHandler
                {
                    PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                    KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                    KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
                    EnableMultipleHttp2Connections = true
                };
                configureChannel.HttpHandler = handler;
            })
            .AddInterceptor<LoggingInterceptor>()
            .Services
            .AddGrpcClient<GameInterfaceAwcRecordService.GameInterfaceAwcRecordServiceClient>((sp, configureClient) =>
            {
                var options = sp.GetRequiredService<IOptions<GameInterfaceAwcServiceClientOptions>>().Value;
                configureClient.Address = options.BaseUrl;
            })
            .ConfigureChannel((sp, configureChannel) =>
            {
                var handler = new SocketsHttpHandler
                {
                    PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                    KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                    KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
                    EnableMultipleHttp2Connections = true
                };
                configureChannel.HttpHandler = handler;
            })
            .AddInterceptor<LoggingInterceptor>()
            .Services
            .AddSingleton<DiagnosticsInterceptorOptions>()
            .AddSingleton<LoggingInterceptor>()
            .AddTransient<IGameInterfaceAwcServiceGrpc, GameInterfaceAwcServiceGrpc>()
            .AddTransient<IGameInterfaceAwcRecordServiceGrpc, GameInterfaceAwcRecordServiceGrpc>();
}
