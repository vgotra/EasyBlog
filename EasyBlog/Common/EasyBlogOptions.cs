namespace EasyBlog.Common;

class EasyBlogOptions
{
    public const string ConfigurationSectionName = "EasyBlog";

    public SupportedDatabaseProviders DatabaseProvider { get; set; }
}