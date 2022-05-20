using System;
using System.IO;
using OpenDV.Core.Configuration;

namespace OpenDV.Core.Resources;

internal static class BinaryWriterExtensions
{
    public static void WritePackedString(this BinaryWriter writer, String text)
    {
        var textBytes = TextConfig.Encoding.GetBytes(text);

        writer.Write((UInt16)textBytes.Length);
        writer.Write(textBytes);
    }

    public static void Write(this BinaryWriter writer, CompressedImage image)
    {
        writer.Write((Byte)image.ImageFormat);
        writer.Write(image.ImageData.Length);
        writer.Write(image.ImageData);
    }

    public static void Write(this BinaryWriter writer, Vector2<UInt16> vector)
    {
        writer.Write(vector.X);
        writer.Write(vector.Y);
    }
}
