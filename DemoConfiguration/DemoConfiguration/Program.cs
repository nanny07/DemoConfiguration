// Install nuget package Microsoft.Extensions.Configuration
using DemoCommon;
using Microsoft.Extensions.Configuration;

var environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? string.Empty;

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()

#region InMemoryConfiguration
    // Microsoft.Extensions.Configuration.Memory
    .AddInMemoryCollection(new Dictionary<string, string?>()
    {
        ["DemoKey"] = "From Memory",
        ["DemoOtherKey"] = "Other From Memory"
    })
#endregion

#region Command line configuration
    // Microsoft.Extensions.Configuration.CommandLine
    .AddCommandLine(args) // From CommandLine
#endregion

#region Environment variables configuration
    //Microsoft.Extensions.Configuration.EnvironmentVariables
    .AddEnvironmentVariables() // From EnvVar
#endregion

#region From JSON files
    // Microsoft.Extensions.Configuration.Json
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .AddJsonFile($"appsettings.{environmentName}.json", true, true);
#endregion

IConfiguration configuration = configurationBuilder.Build();

ConfigurationUtility.WriteKeyToConsole(configuration, "DemoKey");
ConfigurationUtility.WriteKeyToConsole(configuration, "DemoOtherKey");
