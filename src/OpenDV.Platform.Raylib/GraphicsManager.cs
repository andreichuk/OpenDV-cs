using OpenDV.Core.Geometry;
using OpenDV.Core.Platform;

namespace OpenDV.Platform.Raylib;

public sealed class GraphicsManager : IGraphicsManager
{
    public void Clear(Color color)
    {
        NativeWrapper.ClearBackground(color.ToNative());
    }

    public void BeginDrawing()
    {
        NativeWrapper.BeginDrawing();
    }

    public void EndDrawing()
    {
        NativeWrapper.EndDrawing();
    }

    public void DrawCircle(Vector2 center, Double radius, Color color)
    {
        NativeWrapper.DrawCircle(
            center.X,
            center.Y,
            (Single)radius,
            color.ToNative()
        );
    }
}
