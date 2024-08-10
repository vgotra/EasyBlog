namespace EasyBlog;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services, HostBuilderContext context)
    {
        var configuration = context.Configuration;
        
        services.AddDbContextPool<EasyBlogDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default")));
    }
}