dotnet build -c Release
dotnet pack .\Src\Quartz.DependencyInjection.Microsoft -c Release -o ..\..\artifacts --include-symbols --no-build --no-restore
