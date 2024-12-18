using Microsoft.Extensions.Configuration;

namespace DemoCommon
{
    public static class ConfigurationUtility
    {
        public static void WriteKeyToConsole(IConfiguration configuration, string key)
        {
            Console.WriteLine("{0}: {1}", key, configuration[key]);
        }
    }
}
