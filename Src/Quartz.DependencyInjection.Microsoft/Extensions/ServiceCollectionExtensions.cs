using Microsoft.Extensions.DependencyInjection;
using Quartz.Impl;

namespace Quartz.DependencyInjection.Microsoft.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQuartz(this IServiceCollection services)
        {
            services.AddSingleton<ISchedulerFactory, SchedulerFactory>();
            services.AddSingleton<ScopedJobFactory>();

            return services;
        }
    }
}
