namespace EasyBlog.Configurations;

static class ConfigurationDataAccessSqlite
{
    public static void ConfigureDataAccessSqLite(this IServiceCollection services, HostBuilderContext context)
    {
        services.AddDbContextPool<EasyBlogDbContextBase, EasyBlogDbContextSqLite>(options => _ = options.UseSqlite(context.Configuration.GetConnectionString("DefaultConnectionSqLite")));
    }
}