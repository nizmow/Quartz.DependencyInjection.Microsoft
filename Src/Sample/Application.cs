using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Sample.Jobs;

namespace Sample
{
    public class Application
    {
        private readonly ISchedulerFactory schedulerFactory;

        public Application(ISchedulerFactory schedulerFactory)
        {
            this.schedulerFactory = schedulerFactory;
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            var scheduler = await this.schedulerFactory.GetScheduler();

            var job = JobBuilder.Create<MyJob>().WithIdentity("MyJob", "MyJob Group").Build();
            var trigger = TriggerBuilder.Create()
                .WithSimpleSchedule(s =>
                {
                    s.RepeatForever();
                    s.WithIntervalInSeconds(1);
                })
                .StartNow()
                .Build();

            await scheduler.ScheduleJob(job, trigger, cancellationToken);
            await scheduler.Start(cancellationToken);

            await Task.Delay(TimeSpan.FromSeconds(30), cancellationToken);

            await scheduler.Shutdown(cancellationToken);
        }
    }
}
