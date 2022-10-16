using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StrikeClient.Infrastructure
{
    public static class StrikeContainerRegistration
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new StrikeConfiguration
            {
                ApiKey = configuration["Strike:Key"],
                Endpoint = configuration["Strike:Endpoint"]
            });

            services.AddHttpClient<StrikeClient>();
        }
    }
}
