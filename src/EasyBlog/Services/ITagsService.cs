using EasyBlog.Models.Tags;

namespace EasyBlog.Services;

public interface ITagsService
{
    Task<List<TagViewModel>> GetAllAsync(CancellationToken cancellationToken);
}