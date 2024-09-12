namespace EasyBlog.Common;

public record DefaultAuthOptions
{
    public bool CreateDefaultUser { get; set; }
    public string DefaultUserName { get; set; } = string.Empty;
    public string DefaultUserEmail { get; set; } = string.Empty;
    public string DefaultUserPassword { get; set; } = string.Empty;
}