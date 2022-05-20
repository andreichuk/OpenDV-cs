using System;
using OpenDV.Core.Configuration;
using OpenDV.Core.Geometry;

namespace OpenDV.Core.Platform;

public readonly record struct Color(
    Byte RedChannel,
    Byte GreenChannel,
    Byte BlueChannel,
    Byte AlphaChannel)
{
    public static readonly Color White = new Color(255, 255, 255, 255);
    public static readonly Color Black = new Color(0, 0, 0, 255);
    public static readonly Color Transparent = new Color(0, 0, 0, 0);
}

public readonly record struct AppTime(Double Total, Double Frame);

public sealed record FrameCtx(
    IPlatform Platform,
    AppTime Time
);

public interface IGraphicsManager
{
    void Clear(Color color);
    void BeginDrawing();
    void EndDrawing();
    void DrawCircle(Vector2 center, Double radius, Color color);
}

public interface IInputManager
{
    Vector2 GetMousePosition();
}

public interface ICursorManager
{
    void HideCursor();
    void ShowCursor();
}

public interface IPlatform
{
    ICursorManager Cursor { get; }
    IInputManager Input { get; }
    IGraphicsManager Graphics { get; }
}

public delegate void InitAction(IPlatform platform);

public delegate void FrameAction(FrameCtx frameCtx);

public sealed record PlatformCtx(
    AppConfig AppConfig,
    String WindowTitle,
    InitAction InitAction,
    FrameAction FrameAction
);
