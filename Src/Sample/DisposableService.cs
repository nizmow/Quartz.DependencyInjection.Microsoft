using System;

namespace Sample
{
    public class DisposableService : IDisposableService
    {
        private readonly IDatabaseService databaseService;

        public DisposableService(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public void DoSomething()
        {
            Console.WriteLine("DisposableService is doing something using the database!");
            this.databaseService.PerformDatabaseActions();

        }

        public void Dispose() => Console.WriteLine("DisposableService is being disposed!");
    }
}
