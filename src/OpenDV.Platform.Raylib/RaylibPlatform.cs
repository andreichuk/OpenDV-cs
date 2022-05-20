using OpenDV.Core.Platform;

namespace OpenDV.Platform.Raylib;

internal sealed record RaylibPlatform(
    ICursorManager Cursor,
    IInputManager Input,
    IGraphicsManager Graphics
) : IPlatform;
