using System.Net;
using Tgs.GameInterface.AwcService.Core;
using Tgs.GameInterface.AwcService.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAwcServiceRepositories(this IServiceCollection services)
            => services
                .AddHttpClient<IGameApiClient, GameApiClient>()
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                })
                .Services;
    }
}
