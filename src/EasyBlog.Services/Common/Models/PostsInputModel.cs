namespace EasyBlog.Services.Common.Models;

public record PostsInputModel : BaseInputModel
{
    public string? SearchQuery { get; set; }
}