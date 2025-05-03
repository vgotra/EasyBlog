namespace EasyBlog.Services;

class PostsService(EasyBlogDbContextBase dbContext) : IPostsService
{
    /// <remarks>
    /// For AOT EF.CompileAsyncQuery((EasyBlogDbContextBase context) => context.Posts.AsNoTracking().Where(x => x.IsPublished));
    /// </remarks>>
    
    public async Task<PostListPageModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken)
    {
        var posts = await dbContext.Posts.AsNoTracking().Where(x => x.IsPublished).OrderByDescending(x => x.CreatedDate).Skip((inputModel.PageNumber - 1) * inputModel.PageSize).Take(inputModel.PageSize).ToListAsync(cancellationToken);
        var total = await dbContext.Posts.AsNoTracking().Where(x => x.IsPublished).CountAsync(cancellationToken);

        return inputModel.ToListViewModel(posts, total);
    }
}