namespace EasyBlog.Extensions;

[Mapper]
public static partial class PostsMappingExtensions
{
    public static partial PostViewModel ToModel(this PostEntity entity);

    public static PostsListViewModel ToListViewModel(this PostsInputModel model, List<PostEntity> posts, int totalRecords) =>
        new()
        {
            Posts = posts.Select(x => x.ToModel()).ToList(),
            PageNumber = model.PageNumber,
            PageSize = model.PageSize,
            TotalRecords = totalRecords
        };
}