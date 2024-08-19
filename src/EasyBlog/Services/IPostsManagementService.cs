namespace EasyBlog.Services;

public interface IPostsManagementService
{
    Task<PostManagementListViewModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken);
    Task<PostManagementViewModel?> GetPostByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddPostAsync(PostEntity post, CancellationToken cancellationToken);
    Task UpdatePostAsync(PostEntity post, CancellationToken cancellationToken);
}