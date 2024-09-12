namespace EasyBlog.Services.Common.Models;

public record SettingsModel
{
    public LanguageModel DefaultLanguage { get; set; } = new() { Id = 1, Name = "Ukrainian", Code = "uk-UA" }; // Default language

    public List<LanguageModel> SupportedLanguages { get; set; } = [];
}