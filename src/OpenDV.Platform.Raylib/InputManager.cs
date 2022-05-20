using OpenDV.Core.Geometry;
using OpenDV.Core.Platform;

namespace OpenDV.Platform.Raylib;

internal sealed class InputManager : IInputManager
{
    public Vector2 GetMousePosition()
    {
        return NativeWrapper.GetMousePosition().ToManagedVector2();
    }
}
