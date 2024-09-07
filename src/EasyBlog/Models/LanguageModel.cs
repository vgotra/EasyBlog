namespace EasyBlog.Models;

public record LanguageModel
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Code { get; init; }
}