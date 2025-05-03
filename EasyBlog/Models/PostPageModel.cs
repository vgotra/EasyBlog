namespace EasyBlog.Models;

public class PostPageModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string ReadableUrl { get; set; } = string.Empty;
}