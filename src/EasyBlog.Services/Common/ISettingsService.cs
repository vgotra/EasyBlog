using EasyBlog.Services.Common.Models;

namespace EasyBlog.Services.Common;

public interface ISettingsService
{
    Task<SettingsModel> GetSettingsAsync(CancellationToken cancellationToken = default);
}