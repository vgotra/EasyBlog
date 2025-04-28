namespace EasyBlog.Services;

class PostsService(EasyBlogDbContextBase dbContext) : IPostsService
{
    public async Task<PostListViewModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken)
    {
        var posts = await dbContext.Posts.AsNoTracking().Where(x => x.IsPublished).OrderByDescending(x => x.CreatedDate).ApplyPaging(inputModel).ToListAsync(cancellationToken);
        var total = await dbContext.Posts.AsNoTracking().Where(x => x.IsPublished).CountAsync(cancellationToken);

        return inputModel.ToListViewModel(posts, total);
    }
}