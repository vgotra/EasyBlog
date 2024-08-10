namespace EasyBlog.DataAccess.Entities;

public class PostEntity : Entity<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsPublished { get; set; } = false;
    public string ReadableUrl { get; set; } = string.Empty;
    public DateTimeOffset? PublishOnDate { get; set; }
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
}