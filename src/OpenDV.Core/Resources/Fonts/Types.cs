using System;
using System.Collections.Generic;

namespace OpenDV.Core.Resources.Fonts;

public sealed record PackedFontCharacter(
    Char Character,
    UInt32 Offset,
    UInt16 Width
);

public sealed record PackedFont(
    String Id,
    UInt16 Height,
    Vector2<UInt16> Offset,
    IReadOnlyCollection<PackedFontCharacter> Characters
);

public sealed record PackedFontFile(
    IReadOnlyCollection<PackedFont> Fonts,
    CompressedImage Image
);
