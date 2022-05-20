using System.Runtime.InteropServices;

namespace OpenDV.Platform.Raylib;

internal static class NativeWrapper
{
    private const String libraryName = "raylib";
    private const CallingConvention callingConvention = CallingConvention.Cdecl;

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2
    {
        public Single x;
        public Single y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Color
    {
        public Byte r;
        public Byte g;
        public Byte b;
        public Byte a;
    }

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern void InitWindow(Int32 width, Int32 height, IntPtr title);

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern Boolean WindowShouldClose();

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern void CloseWindow();

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern void SetTargetFPS(Int32 fps);

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern Vector2 GetMousePosition();

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern void ShowCursor();

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern void HideCursor();

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern Double GetTime();

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern Single GetFrameTime();

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern void ClearBackground(Color color);

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern void BeginDrawing();

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern void EndDrawing();

    [DllImport(libraryName, CallingConvention = callingConvention)]
    public static extern void DrawCircle(
        Int32 centerX,
        Int32 centerY,
        Single radius,
        Color color
    );
}
