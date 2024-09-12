namespace EasyBlog.Services.Common.Models;

public record LanguageModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}