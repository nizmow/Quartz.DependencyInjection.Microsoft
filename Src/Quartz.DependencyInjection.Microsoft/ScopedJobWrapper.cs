using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Quartz.DependencyInjection.Microsoft
{
    internal class ScopedJobWrapper : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly Type job;

        public ScopedJobWrapper(IServiceScopeFactory serviceScopeFactory, Type job)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.job = job;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                try
                {
                    if (scope.ServiceProvider.GetService(this.job) is IJob currentJob)
                    {
                        await currentJob.Execute(context);
                    }
                }
                catch (JobExecutionException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw new JobExecutionException($"Failed to exexcute job '{context.JobDetail.Key}' of type '{context.JobDetail.JobType}", e);
                }
            }
        }
    }
}
