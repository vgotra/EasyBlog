using System.IO.Compression;
using EasyBlog.DataAccess.Repositories.PostgresSql;
using Microsoft.AspNetCore.ResponseCompression;

namespace EasyBlog;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services, HostBuilderContext context)
    {
        var configuration = context.Configuration;
        var provider = configuration.GetValue("EasyBlog:DatabaseProvider", SupportedDatabaseProviders.PostgresSql);

        services.AddDbContextPool<EasyBlogDbContext>(options => _ = provider switch
        {
            SupportedDatabaseProviders.PostgresSql => options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnectionPostgresSql"))
                .UseModel(DataAccess.Compiledmodels.EasyBlogDbContextModel.Instance), //TODO Check for compiled models
            // SupportedDatabaseProviders.SqlServer => options
            //     .UseSqlServer(configuration.GetConnectionString("DefaultConnectionSqlServer"))
            //     .UseModel(DataAccess.Compiledmodels.EasyBlogDbContextModel.Instance),
            _ => throw new Exception($"Unsupported provider: {provider}")
        });

        services.AddScoped<IPostsRepository, PostsRepository>();
    }

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