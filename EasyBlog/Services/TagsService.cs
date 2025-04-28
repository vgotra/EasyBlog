namespace EasyBlog.Services;

class TagsService(EasyBlogDbContextBase dbContext) : ITagsService
{
    public async Task<List<TagPageModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var tags = await dbContext.Tags.AsNoTracking().ToListAsync(cancellationToken);
        return tags.Select(x => x.ToModel()).ToList()!;
    }
}