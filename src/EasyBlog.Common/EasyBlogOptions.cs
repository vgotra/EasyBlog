namespace EasyBlog.Common;

public record EasyBlogOptions
{
    public const string ConfigurationSectionName = "EasyBlog";

    public SupportedDatabaseProviders DatabaseProvider { get; set; }

    public DefaultAuthOptions DefaultAuth { get; set; } = null!;
}