using EasyBlog.Models.Tags;

namespace EasyBlog.Extensions;

[Mapper]
public static partial class ModelsMappingExtensions
{
    public static partial PostViewModel? ToModel(this PostEntity? entity);

    public static PostListViewModel ToListViewModel(this PostsInputModel model, List<PostEntity> posts, int totalRecords) =>
        new()
        {
            Posts = posts.Select(x => x.ToModel()).Where(x => x != null).ToList()!,
            PageNumber = model.PageNumber,
            PageSize = model.PageSize,
            TotalRecords = totalRecords,
        };

    public static partial TagViewModel? ToModel(this TagEntity? entity);
}