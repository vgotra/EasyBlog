namespace EasyBlog.DataAccessLayer.Sqlite;

public interface IPostsRepository
{
    Task<Posts> GetPostsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
}