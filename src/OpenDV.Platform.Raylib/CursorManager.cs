using OpenDV.Core.Platform;

namespace OpenDV.Platform.Raylib;

internal sealed class CursorManager : ICursorManager
{
    public void HideCursor()
    {
        NativeWrapper.HideCursor();
    }

    public void ShowCursor()
    {
        NativeWrapper.ShowCursor();
    }
}
