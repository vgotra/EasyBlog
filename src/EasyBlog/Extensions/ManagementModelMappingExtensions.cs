namespace EasyBlog.Extensions;

[Mapper]
public static partial class ManagementModelMappingExtensions
{
    [MapperIgnoreTarget(nameof(PostManagementViewModel.Tags))]
    private static partial PostManagementViewModel? MapToManagementModel(this PostEntity? entity);

    [UserMapping(Default = true)]
    public static PostManagementViewModel? ToManagementModel(this PostEntity? entity)
    {
        var model = MapToManagementModel(entity);
        if (model != null && entity?.Tags != null)
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

    [MapperIgnoreTarget(nameof(PostEntity.Tags))]
    private static partial PostEntity MapToEntity(this PostManagementViewModel entity);

    [UserMapping(Default = true)]
    public static PostEntity ToEntity(this PostManagementViewModel entity)
    {
        var model = MapToEntity(entity);
        var tags = entity.Tags?.Split(',').Select(x => new TagEntity { Name = x }).ToList();
        if (tags != null)
            model.Tags.AddRange(tags);
        return model;
    }
}