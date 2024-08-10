namespace EasyBlog.DataAccess.Repositories;

public interface IPostsRepository
{
    Task<(List<PostEntity> Posts, int Total)> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken);
}