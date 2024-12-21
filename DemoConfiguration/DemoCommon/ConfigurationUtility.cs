using Microsoft.Extensions.Configuration;
using Console = VSConsole.Console;

namespace DemoCommon
{
    public static class ConfigurationUtility
    {
        public static void WriteKeyToVSConsole(IConfiguration configuration, string key)
        {
            Console.WriteLine("{0}: {1}", key, configuration[key]);
            Console.WriteLine(string.Empty);
        }

        public static void WriteToVSConsole(string value)
        {
            Console.WriteLine(value);
            Console.WriteLine(string.Empty);
        }
    }
}
