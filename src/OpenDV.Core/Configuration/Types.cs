using System;
using OpenDV.Core.Geometry;

namespace OpenDV.Core.Configuration;

public sealed record ResourceConfig(
    String DataFolderPath,
    String FontFilePath);

public sealed record AppConfig(
    Size Resolution,
    ResourceConfig Resource);
