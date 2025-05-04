using Microsoft.Data.Sqlite;

namespace EasyBlog.Configurations;

static class ConfigurationDataAccessSqlite
{
    public static void ConfigureDataAccessSqLite(this IServiceCollection services, IConfiguration configuration)
    {
        _ = configuration.GetValue("EasyBlog:DatabaseProvider", SupportedDatabaseProviders.SqLite);
        services.AddScoped<SqliteConnection>(_ => new SqliteConnection(configuration.GetConnectionString("DefaultConnectionSqLite")));
    }
}