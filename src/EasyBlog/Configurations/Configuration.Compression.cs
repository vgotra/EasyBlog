﻿using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;

namespace EasyBlog.Configurations;

public static class ConfigurationCompression
{
    public static void ConfigureCompression(this IServiceCollection services, HostBuilderContext context)
    {
        services.AddResponseCompression(options =>
        {
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
            options.EnableForHttps = true;
        });

        services.Configure<BrotliCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
        services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.SmallestSize);
    }
}