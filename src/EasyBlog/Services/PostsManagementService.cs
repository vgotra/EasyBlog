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

    public async Task CreatePostAsync(PostManagementViewModel post, CancellationToken cancellationToken)
    {
        //TODO Validate tags, etc
        var entity = post.ToEntity();
        dbContext.Posts.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> UpdatePostAsync(PostManagementViewModel post, CancellationToken cancellationToken)
    {
        //TODO Validate tags, etc
        var entity = post.ToEntity();
        dbContext.Posts.Attach(entity);
        var result = await dbContext.SaveChangesAsync(cancellationToken);
        return result > 0;
    }

    public async Task DeletePostAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await dbContext.Posts.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
    }
}