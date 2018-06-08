using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Spi;

namespace Quartz.DependencyInjection.Microsoft
{
    public class ScopedJobFactory : IJobFactory
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public ScopedJobFactory(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                return new ScopedJobWrapper(this.serviceScopeFactory, bundle.JobDetail.JobType);
            }
            catch (Exception e)
            {
                throw new SchedulerException($"Error instantiating class '{bundle.JobDetail.JobType}", e);
            }
        }

        public void ReturnJob(IJob job)
        {
            // nothing to do here, as the DI container will handle job lifecycles appropriately
        }
    }
}
