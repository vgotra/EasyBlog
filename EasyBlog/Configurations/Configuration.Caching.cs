namespace EasyBlog.Configurations;

static class ConfigurationCaching
{
    /// <remarks>
    /// https://learn.microsoft.com/en-us/aspnet/core/performance/caching/output?view=aspnetcore-8.0
    /// </remarks>
    public static void ConfigureCaching(this IServiceCollection services)
    {
        services.AddOutputCache(options =>
        {
            options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromSeconds(10)));
            options.AddPolicy(Defaults.Cache.NoCachePolicy, builder => builder.NoCache());
        });
    }
}