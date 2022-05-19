using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenDV.Core.Geometry;

namespace OpenDV.Core.Configuration;

public static class ConfigurationReader
{
    public static AppConfig Get(IConfiguration configurationSource, String basePath)
    {
        var resolution = GetResolution(configurationSource);
        var resourceConfig = GetResourceConfig(configurationSource, basePath);

        return
            new AppConfig(
                resolution,
                resourceConfig
            );
    }

    private static Size GetResolution(IConfiguration configurationSource)
    {
        var resolutionConfigurationSource = configurationSource.GetSection("resolution");
        var width = resolutionConfigurationSource?.GetValue<Int32?>("width") ?? 800;
        var height = resolutionConfigurationSource?.GetValue<Int32?>("height") ?? 600;

        return new Size(width, height);
    }

    private static ResourceConfig GetResourceConfig(IConfiguration configurationSource, String basePath)
    {
        var resourceConfigurationSource = configurationSource.GetSection("resources");
        var dataFolderPath =
            resourceConfigurationSource?.GetValue<String?>("dataFolderPath")
            ?? Path.Join(basePath, "Data");

        var fontFilePath =
            resourceConfigurationSource?.GetValue<String?>("fontFilePath")
            ?? Path.Join(dataFolderPath, "Interface", "Fonts.odv");

        return new ResourceConfig(dataFolderPath, fontFilePath);
    }
}
