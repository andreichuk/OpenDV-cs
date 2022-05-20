using OpenDV.Core.Geometry;
using OpenDV.Core.Platform;

namespace OpenDV.Platform.Raylib;

internal static class Extensions
{
    public static NativeWrapper.Color ToNative(this Color color)
    {
        return
            new NativeWrapper.Color
            {
                a = color.AlphaChannel,
                b = color.BlueChannel,
                g = color.GreenChannel,
                r = color.RedChannel
            };
    }

    public static NativeWrapper.Vector2 ToNative(this Vector2 vector2)
    {
        return
            new NativeWrapper.Vector2
            {
                x = vector2.X,
                y = vector2.Y
            };
    }

    public static Vector2 ToManagedVector2(this NativeWrapper.Vector2 vector2)
    {
        return new Vector2((Int32)vector2.x, (Int32)vector2.y);
    }
}
