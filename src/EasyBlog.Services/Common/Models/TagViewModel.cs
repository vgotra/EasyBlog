namespace EasyBlog.Services.Common.Models;

public record TagViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}