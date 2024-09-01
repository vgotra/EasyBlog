namespace EasyBlog.Services;

public interface IPostsManagementService
{
    Task<PostManagementListViewModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken = default);
    Task<PostManagementViewModel?> GetPostByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreatePostAsync(PostManagementViewModel postModel, CancellationToken cancellationToken = default);
    Task UpdatePostAsync(PostManagementViewModel postModel, CancellationToken cancellationToken = default);
    Task DeletePostAsync(Guid id, CancellationToken cancellationToken = default);
}