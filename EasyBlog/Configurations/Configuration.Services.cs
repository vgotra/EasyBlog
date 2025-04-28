namespace EasyBlog.Configurations;

public static class ConfigurationServices
{
    public static void ConfigureServices(this IServiceCollection services, HostBuilderContext context)
    {
        var configuration = context.Configuration;
        _ = configuration.GetValue("EasyBlog:DatabaseProvider", SupportedDatabaseProviders.PostgresSql);

        //INFO for prod can be useful to enable CompiledModels: //.UseModel(DataAccess.Compiledmodels.EasyBlogDbContextModel.Instance)
        services.ConfigureDataAccessSqLite(context);

        services.AddScoped<IPostsService, PostsService>();
        services.AddScoped<ITagsService, TagsService>();

        services.ConfigureCompression(context);
    }
}