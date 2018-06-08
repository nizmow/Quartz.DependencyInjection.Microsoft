using System;

namespace Sample.Jobs
{
    public class DatabaseService : IDatabaseService
    {
        private readonly Guid databaseServiceIdentifier;

        public DatabaseService()
        {
            this.databaseServiceIdentifier = Guid.NewGuid();
        }

        public void PerformDatabaseActions()
        {
            Console.WriteLine($"Database service '{this.databaseServiceIdentifier.ToString()}' performing actions!");
        }
    }
}
