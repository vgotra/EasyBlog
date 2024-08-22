using EasyBlog.Models.Tags;

namespace EasyBlog.Models.Posts;

public class PostManagementViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsPublished { get; set; } = false;
    public string ReadableUrl { get; set; } = string.Empty;
    public DateTimeOffset? PublishOnDate { get; set; }
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

    public List<TagViewModel> Tags { get; } = [];
}