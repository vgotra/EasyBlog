namespace EasyBlog.Areas.Admin.Controllers;

public partial class PostsManagementController
{
    private static PostManagementViewModel CreateTestPost() => new()
    {
        Id = default,
        Title = "Title",
        Content = "Content",
        IsPublished = true,
        ReadableUrl = "/readable/url",
        PublishOnDate = DateTimeOffset.UtcNow,
        CreatedDate = DateTimeOffset.UtcNow
    };
}