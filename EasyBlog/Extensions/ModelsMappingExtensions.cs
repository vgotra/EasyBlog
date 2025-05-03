namespace EasyBlog.Extensions;

static class ModelsMappingExtensions
{
    private static PostPageModel? ToModel(this PostEntity? entity) =>
        entity == null ? null : new PostPageModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Content = entity.Content,
            CreatedDate = entity.CreatedDate, 
            ReadableUrl = entity.ReadableUrl
        };

    public static PostListPageModel ToListViewModel(this PostsInputModel model, List<PostEntity> posts, int totalRecords) =>
        new()
        {
            Posts = posts.Select(x => x.ToModel()).Where(x => x != null).ToList()!,
            PageNumber = model.PageNumber,
            PageSize = model.PageSize,
            TotalRecords = totalRecords
        };

    public static TagPageModel? ToModel(this TagEntity? entity) =>
        entity == null ? null : new TagPageModel { Id = entity.Id, Name = entity.Name };
}