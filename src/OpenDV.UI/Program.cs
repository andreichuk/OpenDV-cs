using System.Reflection;
using Microsoft.Extensions.Configuration;
using OpenDV.Core.Configuration;

namespace OpenDV.UI;

internal static class App
{
    public static void Main()
    {
        var config = GetConfiguration();
    }

    private static AppConfig GetConfiguration()
    {
        var configurationSource =
            new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: true)
                .Build();

        var basePath = Assembly.GetEntryAssembly()!.Location;

        var config = ConfigurationReader.Get(configurationSource, basePath);
        return config;
    }
}
