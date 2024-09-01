namespace EasyBlog.Areas.Admin.Extensions;

[Mapper]
public static partial class PostEntityMappingExtensions
{
    [MapperIgnoreTarget(nameof(PostEntity.Tags))]
    private static partial PostEntity MapToEntity(this PostManagementViewModel model);

    [UserMapping(Default = true)]
    public static PostEntity ToEntity(this PostManagementViewModel model)
    {
        var entity = MapToEntity(model);
        entity.CreatedDate = DateTimeOffset.UtcNow;

        var tags = model.Tags?.Split(',').Select(x => new TagEntity { Name = x }).ToList();
        if (tags != null)
            entity.Tags.AddRange(tags);

        if (entity.PublishOnDate.HasValue)
            entity.PublishOnDate = entity.PublishOnDate.Value.ToUniversalTime();

        return entity;
    }

    public static PostEntity UpdateFrom(this PostEntity postEntity, PostManagementViewModel model)
    {
        postEntity.Title = model.Title;
        postEntity.Content = model.Content;
        postEntity.IsPublished = model.IsPublished;
        postEntity.ReadableUrl = model.ReadableUrl;
        postEntity.PublishOnDate = model.PublishOnDate?.ToUniversalTime();

        return postEntity;
    }
}