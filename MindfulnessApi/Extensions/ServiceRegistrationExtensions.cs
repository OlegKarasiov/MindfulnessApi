using MindfulnessApi.Services.Implimentations;
using MindfulnessApi.Services.Interfaces;

namespace MindfulnessApi.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddTransientServices(this IServiceCollection services)
        {
            services.AddTransient<IMindfulnessService, MindfulnessService>();

            services.AddTransient<ITestService, TestService>();

            return services;
        }
    }
}
