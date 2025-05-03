namespace EasyBlog.Configurations;

static class ConfigurationServices
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        //INFO for prod can be useful to enable CompiledModels: //.UseModel(DataAccess.CompiledModels.EasyBlogDbContextModel.Instance)

        services.AddScoped<IPostsService, PostsService>();
        services.AddScoped<ITagsService, TagsService>();
    }
}