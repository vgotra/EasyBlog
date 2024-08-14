using EasyBlog.DataAccess.PostgresSql;

namespace EasyBlog.Configurations;

public static class ConfigurationDataAccessPostgresSql
{
    public static void ConfigureDataAccessPostgresSql(this IServiceCollection services, HostBuilderContext context)
    {
        var configuration = context.Configuration;

        services.AddDbContextPool<EasyBlogDbContextBase, EasyBlogDbContextBasePostgresSql>(options =>
            _ = options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionPostgresSql")));

        services.AddScoped<IPostsRepository, PostsRepositoryPostgresSql>();
        services.AddScoped<ITagsRepository, TagsRepositoryPostgresSql>();
    }
}