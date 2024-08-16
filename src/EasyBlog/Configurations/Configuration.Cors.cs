namespace EasyBlog.Configurations;

public static class ConfigurationCors
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
            options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
    }
}