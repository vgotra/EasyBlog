using EasyBlog.DataAccess.PostgresSql;

namespace EasyBlog.Configurations;

public static class ConfigurationDataAccessPostgresSql
{
    public static void ConfigureDataAccessPostgresSql(this IServiceCollection services, HostBuilderContext context)
    {
        services.AddDbContextPool<EasyBlogDbContextBase, EasyBlogDbContextPostgresSql>(options => _ = options.UseNpgsql(context.Configuration.GetConnectionString("DefaultConnectionPostgresSql")));
    }
}