using EasyBlog.Services.Common.Extensions;
using EasyBlog.Services.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyBlog.Services.Common;

public class PostsService(EasyBlogDbContextBase dbContext) : IPostsService
{
    public async Task<PostListViewModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken)
    {
        var posts = await dbContext.Posts.AsNoTracking().Include(x => x.Contents)
            .Where(x => x.IsPublished).OrderByDescending(x => x.CreatedDate)
            .ApplyPaging(inputModel.PageNumber, inputModel.PageSize)
            .ToListAsync(cancellationToken);

        var total = await dbContext.Posts.AsNoTracking().Include(x => x.Contents).Where(x => x.IsPublished).CountAsync(cancellationToken);

        return inputModel.ToListViewModel(posts, total);
    }
}