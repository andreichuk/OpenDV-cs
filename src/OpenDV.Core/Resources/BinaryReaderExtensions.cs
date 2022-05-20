using System;
using System.IO;
using OpenDV.Core.Configuration;

namespace OpenDV.Core.Resources;

internal static class BinaryReaderExtensions
{
    public static String ReadPackedString(this BinaryReader reader)
    {
        var textLength = reader.ReadUInt16();
        var textBytes = reader.ReadBytes(textLength);
        return TextConfig.Encoding.GetString(textBytes);
    }

    public static CompressedImage ReadCompressedImage(this BinaryReader reader)
    {
        var imageFormat = (ImageFormat)reader.ReadByte();
        var imageDataLength = reader.ReadUInt16();
        var imageData = reader.ReadBytes(imageDataLength);

        return new CompressedImage(imageFormat, imageData);
    }

    public static Vector2<UInt16> ReadVector2UInt16(this BinaryReader reader)
    {
        var x = reader.ReadUInt16();
        var y = reader.ReadUInt16();

        return new Vector2<UInt16>(x, y);
    }
}
