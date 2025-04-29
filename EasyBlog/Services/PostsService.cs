namespace EasyBlog.Services;

class PostsService(EasyBlogDbContextBase dbContext) : IPostsService
{
    public async Task<PostListPageModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken)
    {
        var postsQuery = EF.CompileAsyncQuery((EasyBlogDbContextBase context) =>
            context.Posts.AsNoTracking().Where(x => x.IsPublished).OrderByDescending(x => x.CreatedDate).Skip((inputModel.PageNumber - 1) * inputModel.PageSize).Take(inputModel.PageSize));
        var totalQuery = EF.CompileAsyncQuery((EasyBlogDbContextBase context) => context.Posts.AsNoTracking().Where(x => x.IsPublished));
        var posts = await postsQuery(dbContext).ToListAsync(cancellationToken);
        var total = await totalQuery(dbContext).CountAsync(cancellationToken);

        return inputModel.ToListViewModel(posts, total);
    }
}