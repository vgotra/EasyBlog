namespace EasyBlog.Services;

interface IPostsService
{
    Task<PostListPageModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken);
}