namespace EasyBlog.BusinessLayer;

public interface IPostsService
{
    Task<PostListPageModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken);
}