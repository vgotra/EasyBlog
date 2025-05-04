namespace EasyBlog.Configurations;

static class ConfigurationServices
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IPostsService, PostsService>();
    }
}