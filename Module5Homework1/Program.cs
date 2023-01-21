using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Module5Homework1;
using Module5Homework1.Config;
using Module5Homework1.Services;
using Module5Homework1.Services.Abstraction;

void ConfigureServices(ServiceCollection services, IConfiguration configuration)
{
    services.AddOptions<ApiOptions>().Bind(configuration.GetSection("Api"));

    services.AddLogging(configure => configure.AddConsole())
        .AddHttpClient()
        .AddTransient<IUserService, UserService>()
        .AddTransient<App>();
}

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var services = new ServiceCollection();
ConfigureServices(services, config);
var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<App>();
await app!.Start();