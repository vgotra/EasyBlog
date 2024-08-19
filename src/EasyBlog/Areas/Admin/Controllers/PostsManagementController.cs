namespace EasyBlog.Areas.Admin.Controllers;

public partial class PostsManagementController(IPostsManagementService service) : AdminControllerBase
{
    public async Task<IActionResult> Index([FromQuery] PostsInputModel? model, CancellationToken cancellationToken = default)
    {
        var viewModel = await service.GetPostsAsync(model ?? new PostsInputModel(), cancellationToken);
#if DEBUG //TODO Temporary to test the view
        if (viewModel.Posts.Count == 0)
            viewModel.Posts.Add(CreateTestPost());
#endif
        return View(viewModel);
    }
}