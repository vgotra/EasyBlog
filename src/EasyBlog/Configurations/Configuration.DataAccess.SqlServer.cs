using EasyBlog.DataAccess.SqlServer;

namespace EasyBlog.Configurations;

public static class ConfigurationDataAccessSqlServer
{
    public static void ConfigureDataAccessSqlServer(this IServiceCollection services, HostBuilderContext context)
    {
        services.AddDbContextPool<EasyBlogDbContextBase, EasyBlogDbContextSqlServer>(options => _ = options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnectionSqlServer")));
    }
}