namespace EasyBlog;

public static class Startup
{
    //TODO Move to configuration and simplify

    public static void ConfigureServices(this IServiceCollection services, HostBuilderContext context)
    {
        var configuration = context.Configuration;
        var provider = configuration.GetValue("EasyBlog:DatabaseProvider", SupportedDatabaseProviders.PostgresSql);

        Console.WriteLine($"Provider: {provider}");

        //INFO for prod can be useful to enable CompiledModels: //.UseModel(DataAccess.Compiledmodels.EasyBlogDbContextModel.Instance)
        if (provider == SupportedDatabaseProviders.PostgresSql)
            services.ConfigureDataAccessPostgresSql(context);
        else if (provider == SupportedDatabaseProviders.SqlServer)
            services.ConfigureDataAccessSqlServer(context);
        else
            throw new Exception($"Unsupported provider: {provider}");

        services.AddScoped<IPostsService, PostsService>();
        services.AddScoped<IPostsManagementService, PostsManagementService>();
        services.AddScoped<ITagsService, TagsService>();

        services.ConfigureCompression(context);
    }
}