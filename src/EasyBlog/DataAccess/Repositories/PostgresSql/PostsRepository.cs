namespace EasyBlog.DataAccess.Repositories.PostgresSql;

public class PostsRepository(EasyBlogDbContext dbContext) : IPostsRepository
{
    public async Task<(List<PostEntity> Posts, int Total)> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken)
    {
        var posts = await dbContext.Posts.AsNoTracking()
            .Where(x => x.IsPublished)
            .OrderByDescending(x => x.CreatedDate)
            .ApplyPaging(inputModel)
            .ToListAsync(cancellationToken);

        var total = await dbContext.Posts.AsNoTracking().Where(x => x.IsPublished).CountAsync(cancellationToken);

        return (posts, total);
    }
}