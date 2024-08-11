namespace EasyBlog.DataAccess.Repositories;

public interface ITagsRepository
{
    Task<List<TagsEntity>> GetAllAsync(CancellationToken cancellationToken);
}