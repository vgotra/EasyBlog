using EasyBlog.DataAccess.PostgresSql;
using EasyBlog.DataAccess.SqlServer;
using Microsoft.AspNetCore.Identity;

namespace EasyBlog.Configurations;

public static class ConfigurationAuth
{
    public static void ConfigureAuth(this IServiceCollection services, HostBuilderContext context)
    {
        var provider = context.Configuration.GetValue("EasyBlog:DatabaseProvider", SupportedDatabaseProviders.PostgresSql);

        //TODO Add some styles for auth UI
        if (provider == SupportedDatabaseProviders.PostgresSql)
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<EasyBlogDbContextPostgresSql>().AddDefaultTokenProviders().AddDefaultUI();
        else if (provider == SupportedDatabaseProviders.SqlServer)
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<EasyBlogDbContextSqlServer>().AddDefaultTokenProviders().AddDefaultUI();

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            options.LoginPath = "/Identity/Account/Login";
            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            options.LogoutPath = "/";
            options.SlidingExpiration = true;
        });
    }
}