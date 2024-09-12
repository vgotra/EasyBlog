using EasyBlog.Services.Common.Models;

namespace EasyBlog.Services.Common;

public class SettingsService : ISettingsService
{
    private readonly List<string> _ignoredLanguagesCodes = ["ru-RU"];

    public Task<SettingsModel> GetSettingsAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}