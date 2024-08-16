namespace EasyBlog.DataAccess.PostgresSql;

public class TagsRepositoryPostgresSql(EasyBlogDbContextPostgresSql dbContext) : ITagsRepository
{
    public async Task<List<TagsEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        //TODO Migrate to 9 to use DistinctBy, etc
        return await dbContext.Tags.AsNoTracking().Distinct().ToListAsync(cancellationToken);
    }
}