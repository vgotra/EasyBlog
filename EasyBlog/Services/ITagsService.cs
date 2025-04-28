namespace EasyBlog.Services;

interface ITagsService
{
    Task<List<TagViewModel>> GetAllAsync(CancellationToken cancellationToken);
}