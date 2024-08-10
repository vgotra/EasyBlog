namespace EasyBlog.DataAccess.Repositories;

public class PostsRepository(EasyBlogDbContext dbContext) : IPostsRepository
{
    public async Task<(List<PostEntity> Posts, int Total)> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken)
    {
        var posts = await dbContext.Posts.AsNoTracking()
            .Where(x => x.IsPublished)
            .ApplySorting(inputModel)
            .ApplyPaging(inputModel)
            .ToListAsync(cancellationToken);

        var total = await dbContext.Posts.AsNoTracking().Where(x => x.IsPublished).CountAsync(cancellationToken);

        return (posts, total);
    }
}