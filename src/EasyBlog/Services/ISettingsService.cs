namespace EasyBlog.Services;

public interface ISettingsService
{
    Task<SettingsModel> GetSettingsAsync(CancellationToken cancellationToken = default);
}