namespace EasyBlog.Areas.Admin.Services;

public class PostsManagementService(EasyBlogDbContextBase dbContext) : IPostsManagementService
{
    public async Task<PostManagementListViewModel> GetPostsAsync(PostsInputModel inputModel, CancellationToken cancellationToken)
    {
        var query = dbContext.Posts.Include(x => x.Tags).AsNoTracking();
        if (!string.IsNullOrWhiteSpace(inputModel.SearchQuery))
            query = query.Where(x => x.Title.Contains(inputModel.SearchQuery) || x.Content.Contains(inputModel.SearchQuery));

        var posts = await query.OrderByDescending(x => x.CreatedDate).ApplyPaging(inputModel).ToListAsync(cancellationToken);
        var total = await query.CountAsync(cancellationToken);

        return inputModel.ToManagementListViewModel(posts, total);
    }

    public async Task<PostManagementViewModel?> GetPostByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var post = await dbContext.Posts.Include(x => x.Tags).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return post.ToManagementModel();
    }

    public async Task CreatePostAsync(PostManagementViewModel postModel, CancellationToken cancellationToken)
    {
        var entity = postModel.ToEntity();
        dbContext.Posts.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdatePostAsync(PostManagementViewModel postModel, CancellationToken cancellationToken)
    {
        var postEntity = await dbContext.Posts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == postModel.Id, cancellationToken);
        if (postEntity == null)
            return;

        var allTags = await dbContext.Tags.AsNoTracking().ToListAsync(cancellationToken);

        postEntity.UpdateFrom(postModel);
        SyncTags(postEntity, postModel, allTags);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private void SyncTags(PostEntity postEntity, PostManagementViewModel postModel, List<TagEntity> allTags)
    {
        var dbTags = postEntity.Tags.ToList();
        var modelTags = postModel.Tags?.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToList() ?? [];

        postEntity.Tags.RemoveAll(tag => modelTags.Find(x => tag.Name.Equals(x, StringComparison.OrdinalIgnoreCase)) == null);

        var newTags = modelTags.Where(tagName => dbTags.All(t => t.Name != tagName)).Select(x => new TagEntity { Name = x }).ToList();
        foreach (var newTag in newTags)
        {
            var existingNewTag = allTags.Find(x => newTag.Name.Equals(x.Name, StringComparison.OrdinalIgnoreCase));
            if (existingNewTag != null)
                newTag.Id = existingNewTag.Id;
        }

        postEntity.Tags.AddRange(newTags);
    }

    public async Task DeletePostAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await dbContext.Posts.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
    }
}