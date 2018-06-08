using Quartz.Core;
using Quartz.Impl;

namespace Quartz.DependencyInjection.Microsoft
{
    public class SchedulerFactory : StdSchedulerFactory
    {
        private readonly ScopedJobFactory jobFactory;

        public SchedulerFactory(ScopedJobFactory jobFactory)
        {
            this.jobFactory = jobFactory;
        }

        protected override IScheduler Instantiate(QuartzSchedulerResources rsrcs, QuartzScheduler qs)
        {
            qs.JobFactory = this.jobFactory;
            return base.Instantiate(rsrcs, qs);
        }
    }
}
