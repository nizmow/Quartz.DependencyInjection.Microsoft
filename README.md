[![Build status](https://ci.appveyor.com/api/projects/status/f4wx7j0npdtnq808?svg=true)](https://ci.appveyor.com/project/nizmow/quartz-dependencyinjection-microsoft)[![NuGet Badge](https://buildstats.info/nuget/Quartz.DependencyInjection.Microsoft)](https://www.nuget.org/packages/Quartz.DependencyInjection.Microsoft/)

# Quartz extensions for Microsoft.Extensions.DependencyInjection

Adds required services to run jobs scoped with dependency injection. Scoping is particularly important if you want to use an Entity Framework inside your Quartz jobs.

To use with an `IServiceCollection`:

```
services.AddQuartz();
```

...and then use an injected `ISchedulerFactory` to obtain a scheduler and configure your jobs from there!

See the sample project for a complete example and demonstration of `IDisposable` and scoped services.

Please fork or add issues if you can think of any other features I can add, but it's a simple implementation and  I think it's pretty complete.

## TODO:

This is a very early release.

* Unit tests
* Automated versioning
