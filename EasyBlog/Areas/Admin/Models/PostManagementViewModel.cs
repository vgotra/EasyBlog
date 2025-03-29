namespace EasyBlog.Areas.Admin.Models;

public class PostManagementViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsPublished { get; set; } = false;
    public string ReadableUrl { get; set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? PublishOnDate { get; set; }
    public string? Tags { get; set; }
}