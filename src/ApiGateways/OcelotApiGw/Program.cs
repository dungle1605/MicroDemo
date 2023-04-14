using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot()
                .AddCacheManager(settings => settings.WithDictionaryHandle());

builder.WebHost
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
    })
    .ConfigureLogging((hostingContext, loggingBuilder) =>
    {
        loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        loggingBuilder.AddConsole();
        loggingBuilder.AddDebug();
    });


var app = builder.Build();
await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
