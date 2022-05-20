using System.Runtime.InteropServices;
using System.Text;
using OpenDV.Core.Geometry;
using OpenDV.Core.Platform;

namespace OpenDV.Platform.Raylib;

public static class PlatformRunner
{
    public static void Run(
        PlatformCtx platformCtx)
    {
        var appConfig = platformCtx.AppConfig;

        var platform =
            new RaylibPlatform(
                new CursorManager(),
                new InputManager(),
                new GraphicsManager()
            );

        platformCtx.InitAction(platform);

        NativeWrapper.SetTargetFPS(30);

        InitWindow(platformCtx.WindowTitle, appConfig.Resolution);
        NativeWrapper.HideCursor();

        while (NativeWrapper.WindowShouldClose() == false)
        {
            var time = GetTime();

            var frameCtx = new FrameCtx(platform, time);
            platformCtx.FrameAction(frameCtx);
        }

        NativeWrapper.CloseWindow();
    }

    private static AppTime GetTime()
    {
        var totalTime = NativeWrapper.GetTime();
        var frameTime = NativeWrapper.GetFrameTime();

        return new AppTime(totalTime, frameTime);
    }

    private static void InitWindow(String title, Size resolution)
    {
        var textBytesNullTerminated = new Byte[title.Length + 1];
        Encoding.ASCII.GetBytes(
            title,
            0,
            title.Length,
            textBytesNullTerminated,
            0
        );

        var handle = GCHandle.Alloc(textBytesNullTerminated, GCHandleType.Pinned);
        NativeWrapper.InitWindow(resolution.Width, resolution.Height, handle.AddrOfPinnedObject());
        handle.Free();
    }
}
