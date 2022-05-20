using System.Reflection;
using Microsoft.Extensions.Configuration;
using OpenDV.Core.Configuration;
using OpenDV.Core.Platform;
using OpenDV.Platform.Raylib;

namespace OpenDV.UI;

internal static class App
{
    public static void Main()
    {
        var config = GetConfiguration();
        var platformCtx = new PlatformCtx(config, "OpenDV", InitAction, FrameAction);
        PlatformRunner.Run(platformCtx);
    }

    private static void InitAction(IPlatform platform) { }

    private static void FrameAction(FrameCtx frameCtx)
    {
        var platform = frameCtx.Platform;
        var mousePosition = platform.Input.GetMousePosition();

        frameCtx.Platform.Graphics.Clear(Color.White);
        frameCtx.Platform.Graphics.BeginDrawing();
        frameCtx.Platform.Graphics.DrawCircle(mousePosition, 5, Color.Black);
        frameCtx.Platform.Graphics.EndDrawing();
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
