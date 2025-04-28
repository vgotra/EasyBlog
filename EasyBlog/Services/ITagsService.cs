namespace EasyBlog.Services;

interface ITagsService
{
    Task<List<TagPageModel>> GetAllAsync(CancellationToken cancellationToken);
}