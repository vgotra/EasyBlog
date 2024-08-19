using EasyBlog.Models.Tags;

namespace EasyBlog.Services;

public class TagsService(EasyBlogDbContextBase dbContext) : ITagsService
{
    public async Task<List<TagViewModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var tags = await dbContext.Tags.AsNoTracking().Distinct().ToListAsync(cancellationToken);
        return tags.Select(x => x.ToModel()).ToList()!;
    }
}