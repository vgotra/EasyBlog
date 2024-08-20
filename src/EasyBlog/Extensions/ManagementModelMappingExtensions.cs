namespace EasyBlog.Extensions;

[Mapper]
public static partial class ManagementModelMappingExtensions
{
    //TODO Don't forget about tags
    public static partial PostManagementViewModel? ToManagementModel(this PostEntity? entity);

    public static PostManagementListViewModel ToManagementListViewModel(this PostsInputModel model, List<PostEntity> posts, int totalRecords)
    {
        return new PostManagementListViewModel
        {
            Posts = posts.Select(x => x.ToManagementModel()).Where(x => x != null).ToList()!,
            PageNumber = model.PageNumber,
            PageSize = model.PageSize,
            TotalRecords = totalRecords,
            SearchQuery = model.SearchQuery
        };
    }

    public static partial PostEntity ToEntity(this PostManagementViewModel entity);
}