using Microsoft.Extensions.DependencyInjection;

namespace OrderingApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add application services registrations here
            return services;
        }
    }
}
