namespace EasyBlog.Models;

public class PostViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string CreatedDate { get; set; } = string.Empty;
    public string ReadableUrl { get; set; } = string.Empty;
}