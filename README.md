[![Build status](https://ci.appveyor.com/api/projects/status/f4wx7j0npdtnq808?svg=true)](https://ci.appveyor.com/project/nizmow/quartz-dependencyinjection-microsoft)

# Quartz extensions for Microsoft.Extensions.DependencyInjection

Adds required services to run jobs scoped with dependency injection. Scoping is particularly important if you want to use an Entity Framework inside your Quartz jobs.

To use with an `IServiceCollection`:

```
services.AddQuartz();
```

See the sample project for a complete example and demonstration of `IDisposable` and scoped services.

## TODO:

This is a very early release

* Unit tests
