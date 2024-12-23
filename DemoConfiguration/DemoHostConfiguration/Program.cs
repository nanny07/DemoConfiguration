﻿// Install package Microsoft.Extensions.Hosting
using DemoCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? string.Empty;

// All we need to do is to create a HostBuilder and build it.
// https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration#alternative-hosting-approach
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
IHost host = builder.Build();

var configuration = host.Services.GetRequiredService<IConfiguration>();

// Priority (lower is higher):
// 5. appsettings.json
// 4. appsettings.{env}.json
// 3. UserSecret (if Development)
// 2. EnvVar
// 1. CommandLine

ConfigurationUtility.WriteToVSConsole($"Environment: {environmentName}");
ConfigurationUtility.WriteKeyToVSConsole(configuration, "DemoKey");
ConfigurationUtility.WriteKeyToVSConsole(configuration, "DemoOtherKey");
ConfigurationUtility.WriteKeyToVSConsole(configuration, "UserSecretKey");

// Tipically, you would run the host like this:
//await host.RunAsync();