namespace EasyBlog.Controllers;

public class HomeController(IPostsRepository postsRepository) : Controller
{
    public async Task<IActionResult> Index([FromQuery] PostsInputModel? request, CancellationToken cancellationToken = default)
    {
        //TODO Add View Components later
        var postsRequest = request ?? new();
        var (posts, total) = await postsRepository.GetPostsAsync(postsRequest, cancellationToken);
        var model = postsRequest.ToListViewModel(posts, total);
        return View(model);
    }

    public IActionResult Privacy() => View();
}