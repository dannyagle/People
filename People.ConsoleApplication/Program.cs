using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using People.Common.Repositories;
using People.Common.Services;
using People.ConsoleApplication.Services;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IPeopleRepository, PeopleRepository>();
        services.AddSingleton<IPeopleService, PeopleService>();
        services.AddHostedService<LotteryService>();
    })
    .Build();

await host.RunAsync();
