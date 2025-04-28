namespace EasyBlog.Controllers;

[AllowAnonymous]
[OutputCache]
public class PostsController(IPostsService postsService) : Controller
{
    public async Task<IActionResult> Index([FromQuery] PostsInputModel? request, CancellationToken cancellationToken = default)
    {
        //TODO Add View Components later
        var postsRequest = request ?? new PostsInputModel();
        var model = await postsService.GetPostsAsync(postsRequest, cancellationToken);
        return View(model);
    }

    public IActionResult Privacy() => View();
}