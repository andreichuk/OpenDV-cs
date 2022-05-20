using System;
using System.IO;

namespace OpenDV.Core.Resources.Fonts;

public static class PackedFontReader
{
    public static PackedFontFile Read(BinaryReader reader)
    {
        var fontCount = reader.ReadByte();
        var fonts = new PackedFont[fontCount];

        for (var index = 0; index < fontCount; index += 1)
        {
            fonts[index] = ReadFont(reader);
        }

        var compressedImage = reader.ReadCompressedImage();
        return
            new PackedFontFile(
                fonts,
                compressedImage
            );
    }

    private static PackedFont ReadFont(BinaryReader reader)
    {
        var id = reader.ReadPackedString();
        var height = reader.ReadUInt16();
        var offset = reader.ReadVector2UInt16();
        var characterCount = reader.ReadUInt16();
        var characters = new PackedFontCharacter[characterCount];

        for (var index = 0; index < characterCount; index += 1)
        {
            characters[index] = ReadFontCharacter(reader);
        }

        return new PackedFont(id, height, offset, characters);
    }

    private static PackedFontCharacter ReadFontCharacter(BinaryReader reader)
    {
        var character = (Char)reader.ReadByte();
        var offset = reader.ReadUInt32();
        var width = reader.ReadUInt16();

        return new PackedFontCharacter(character, offset, width);
    }
}
