namespace EasyBlog.Services.Common.Models;

public record PostViewModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTimeOffset CreatedDate { get; set; }

    public string ReadableUrl { get; set; } = string.Empty;
}