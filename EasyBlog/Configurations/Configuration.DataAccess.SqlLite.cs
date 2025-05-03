namespace EasyBlog.Configurations;

static class ConfigurationDataAccessSqlite
{
    public static void ConfigureDataAccessSqLite(this IServiceCollection services, IConfiguration configuration)
    {
        _ = configuration.GetValue("EasyBlog:DatabaseProvider", SupportedDatabaseProviders.SqLite);
        services.AddDbContextPool<EasyBlogDbContextBase, EasyBlogDbContextSqLite>(options =>
            _ = options
                .UseModel(DataAccess.CompiledModels.EasyBlogDbContextSqLiteModel.Instance)
                .UseSqlite(configuration.GetConnectionString("DefaultConnectionSqLite")));
    }
}