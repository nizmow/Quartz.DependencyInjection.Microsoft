using System;
using System.Threading.Tasks;
using Quartz;

namespace Sample.Jobs
{
    [DisallowConcurrentExecution]
    public class MyJob : IJob
    {
        private readonly IDisposableService disposableService;
        private readonly IDatabaseService databaseService;

        public MyJob(IDisposableService disposableService, IDatabaseService databaseService)
        {
            this.disposableService = disposableService;
            this.databaseService = databaseService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("======================");
            Console.WriteLine("Job execution starting!");

            this.databaseService.PerformDatabaseActions();
            this.disposableService.DoSomething();

            return Task.CompletedTask;
        }
    }
}
