using EasyBlog.Services.Common.Models;

namespace EasyBlog.Services.Common;

public interface ITagsService
{
    Task<List<TagViewModel>> GetAllAsync(CancellationToken cancellationToken);
}