using EasyBlog.Services.Common.Models;

namespace EasyBlog.Services.Common;

public interface IPostsService
{
    Task<PostListViewModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken);
}