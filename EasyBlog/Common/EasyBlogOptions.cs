namespace EasyBlog.Common;

public class EasyBlogOptions
{
    public const string ConfigurationSectionName = "EasyBlog";

    public SupportedDatabaseProviders DatabaseProvider { get; set; }

    public DefaultAuthOptions DefaultAuth { get; set; } = null!;
}

public class DefaultAuthOptions
{
    public bool CreateDefaultUser { get; set; }
    public string DefaultUserName { get; set; } = string.Empty;

    public string DefaultUserEmail { get; set; } = string.Empty;

    public string DefaultUserPassword { get; set; } = string.Empty;
}