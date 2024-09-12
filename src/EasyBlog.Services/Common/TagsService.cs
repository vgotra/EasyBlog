using EasyBlog.Services.Common.Models;
using Microsoft.EntityFrameworkCore;
using ModelsMappingExtensions = EasyBlog.Services.Common.Extensions.ModelsMappingExtensions;

namespace EasyBlog.Services.Common;

public class TagsService(EasyBlogDbContextBase dbContext) : ITagsService
{
    public async Task<List<TagViewModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var tags = await dbContext.Tags.AsNoTracking().ToListAsync(cancellationToken);
        return tags.Select(x => ModelsMappingExtensions.ToModel(x)).ToList()!;
    }
}