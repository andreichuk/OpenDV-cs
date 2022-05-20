using System;
using System.IO;

namespace OpenDV.Core.Resources.Fonts;

public static class PackedFontWriter
{
    public static void Write(BinaryWriter writer, PackedFontFile fontFile)
    {
        writer.Write((Byte)fontFile.Fonts.Count);
        foreach (var font in fontFile.Fonts)
        {
            writer.Write(font);
        }

        writer.Write(fontFile.Image);
    }

    private static void Write(this BinaryWriter writer, PackedFont font)
    {
        writer.WritePackedString(font.Id);
        writer.Write(font.Height);
        writer.Write(font.Offset);
        writer.Write((UInt16)font.Characters.Count);
        foreach (var character in font.Characters)
        {
            writer.Write(character);
        }
    }

    private static void Write(this BinaryWriter writer, PackedFontCharacter character)
    {
        writer.Write((Byte)character.Character);
        writer.Write(character.Offset);
        writer.Write(character.Width);
    }
}
