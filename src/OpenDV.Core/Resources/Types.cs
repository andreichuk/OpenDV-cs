using System;

namespace OpenDV.Core.Resources;

public readonly record struct Vector2<T>(T X, T Y) where T : struct;

public readonly record struct Size<T>(T X, T Y) where T : struct;

public enum ImageFormat : Byte
{
    Png = 1
}

public sealed record CompressedImage(
    ImageFormat ImageFormat,
    Byte[] ImageData
);
