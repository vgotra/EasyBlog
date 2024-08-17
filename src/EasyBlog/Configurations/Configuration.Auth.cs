using EasyBlog.DataAccess.PostgresSql;
using EasyBlog.DataAccess.SqlServer;
using Microsoft.AspNetCore.Identity;

namespace EasyBlog.Configurations;

public static class ConfigurationAuth
{
    public static void ConfigureAuth(this IServiceCollection services, HostBuilderContext context)
    {
        var configuration = context.Configuration;
        var provider = configuration.GetValue("EasyBlog:DatabaseProvider", SupportedDatabaseProviders.PostgresSql);

        //TODO Add some styles for auth UI
        if (provider == SupportedDatabaseProviders.PostgresSql)
        {
            services.AddDbContextPool<IdentityDbContextPostgresSql>(options =>
                _ = options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionPostgresSql")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContextPostgresSql>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();
        }
        else if (provider == SupportedDatabaseProviders.SqlServer)
        {
            services.AddDbContextPool<IdentityDbContextSqlServer>(options =>
                _ = options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionSqlServer")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContextSqlServer>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();
        }

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            options.LoginPath = "/Identity/Account/Login";
            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            options.SlidingExpiration = true;
        });
    }
}