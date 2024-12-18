using DemoCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// All we need to do is to create a HostBuilder and build it.
// https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration#alternative-hosting-approach
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
IHost host = builder.Build();

var configuration = host.Services.GetRequiredService<IConfiguration>();

// Priority: CommandLine -> EnvVar -> UserSecret (if Development) -> appsettings.{env}.json -> appsettings.json

ConfigurationUtility.WriteKeyToConsole(configuration, "DemoKey");
ConfigurationUtility.WriteKeyToConsole(configuration, "DemoOtherKey");
//ConfigurationUtility.WriteKeyToConsole(configuration, "UserSecretKey");

// Tipically, you would run the host like this:
//await host.RunAsync();