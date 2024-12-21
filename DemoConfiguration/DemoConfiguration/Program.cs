// Install nuget package Microsoft.Extensions.Configuration
using DemoCommon;
using Microsoft.Extensions.Configuration;

var environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? string.Empty;

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

#region InMemoryConfiguration
// Microsoft.Extensions.Configuration (included)
//configurationBuilder.AddInMemoryCollection(new Dictionary<string, string?>()
//{
//    ["DemoKey"] = "From Memory",
//    ["DemoOtherKey"] = "Other From Memory"
//});
#endregion

#region Command line configuration
// Microsoft.Extensions.Configuration.CommandLine
//configurationBuilder.AddCommandLine(args); // From CommandLine
#endregion

#region Environment variables configuration
//Microsoft.Extensions.Configuration.EnvironmentVariables
//configurationBuilder.AddEnvironmentVariables(); // From EnvVar
#endregion

#region From JSON files
// Microsoft.Extensions.Configuration.Json
//configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
//configurationBuilder.AddJsonFile($"appsettings.{environmentName}.json", true, true);
#endregion

IConfiguration configuration = configurationBuilder.Build();

ConfigurationUtility.WriteToVSConsole($"Environment: {environmentName}");
ConfigurationUtility.WriteKeyToVSConsole(configuration, "DemoKey");
ConfigurationUtility.WriteKeyToVSConsole(configuration, "DemoOtherKey");