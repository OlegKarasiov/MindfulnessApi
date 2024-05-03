using MindfulnessApi.Services;

namespace MindfulnessApi.Extensions
{
    public static class ServiceRegistrationExtensions
    {

        public static IServiceCollection SeedTests(this IServiceCollection services)
        {
            TestSeeding.StartTestSeeding();

            return services;
        }
    }
}
