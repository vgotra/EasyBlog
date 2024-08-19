namespace EasyBlog.Services;

public class PostsManagementService(EasyBlogDbContextBase dbContext) : IPostsManagementService
{
    public async Task<PostManagementListViewModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken)
    {
        var posts = await dbContext.Posts.AsNoTracking().OrderByDescending(x => x.CreatedDate).ApplyPaging(inputModel).ToListAsync(cancellationToken);
        var total = await dbContext.Posts.AsNoTracking().Where(x => x.IsPublished).CountAsync(cancellationToken);

        return inputModel.ToManagementListViewModel(posts, total);
    }

    public async Task<PostManagementViewModel?> GetPostByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var post = await dbContext.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return post.ToManagementModel();
    }

    public Task AddPostAsync(PostEntity post, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePostAsync(PostEntity post, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}