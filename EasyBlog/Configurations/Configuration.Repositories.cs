using EasyBlog.DataAccessLayer.Sqlite;

namespace EasyBlog.Configurations;

static class ConfigurationRepositories
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPostsRepository, PostsRepository>();
    }
}