namespace EasyBlog.Extensions;

public static partial class ModelsMappingExtensions
{
    public static PostViewModel? ToModel(this PostEntity? entity) =>
        entity == null ? null : new PostViewModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Content = entity.Content,
            CreatedDate = entity.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"), //TODO Culture 
            ReadableUrl = entity.ReadableUrl
        };

    public static PostListViewModel ToListViewModel(this PostsInputModel model, List<PostEntity> posts, int totalRecords) =>
        new()
        {
            Posts = posts.Select(x => x.ToModel()).Where(x => x != null).ToList()!,
            PageNumber = model.PageNumber,
            PageSize = model.PageSize,
            TotalRecords = totalRecords
        };

    public static TagViewModel? ToModel(this TagEntity? entity) =>
        entity == null ? null : new TagViewModel { Id = entity.Id, Name = entity.Name };
}