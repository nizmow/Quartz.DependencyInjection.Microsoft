using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Quartz.DependencyInjection.Microsoft.Extensions;
using Sample.Jobs;

namespace Sample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddQuartz()
                .AddTransient<Application>()
                .AddTransient<IDisposableService, DisposableService>()
                .AddScoped<IDatabaseService, DatabaseService>()
                .AddTransient<MyJob>()
                .BuildServiceProvider();

            await serviceProvider.GetService<Application>().Run(new CancellationToken());
        }
    }
}
