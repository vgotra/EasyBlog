namespace EasyBlog.Services;

public interface IPostsService
{
    Task<PostListViewModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken);
}