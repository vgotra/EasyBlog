namespace EasyBlog.Areas.Admin.Extensions;

[Mapper]
public static partial class PostModelMappingExtensions
{
    [MapperIgnoreTarget(nameof(PostManagementViewModel.Tags))]
    private static partial PostManagementViewModel? MapToManagementModel(this PostEntity? entity);

    [UserMapping(Default = true)]
    public static PostManagementViewModel? ToManagementModel(this PostEntity? entity)
    {
        var model = MapToManagementModel(entity);
        if (model == null || entity?.Tags == null)
            return model;

        if (model.PublishOnDate.HasValue)
            model.PublishOnDate = model.PublishOnDate.Value.ToLocalTimeBasedOnCulture();

        model.Tags = string.Join(',', entity.Tags.Select(x => x.Name));
        return model;
    }

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
}