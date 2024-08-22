namespace EasyBlog.Services;

public interface IPostsManagementService
{
    Task<PostManagementListViewModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken = default);
    Task<PostManagementViewModel?> GetPostByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreatePostAsync(PostManagementViewModel post, CancellationToken cancellationToken = default);
    Task<bool> UpdatePostAsync(PostManagementViewModel post, CancellationToken cancellationToken = default);
    Task DeletePostAsync(Guid id, CancellationToken cancellationToken = default);
}