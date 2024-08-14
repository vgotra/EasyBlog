namespace EasyBlog.DataAccess;

public interface ITagsRepository
{
    Task<List<TagsEntity>> GetAllAsync(CancellationToken cancellationToken);
}