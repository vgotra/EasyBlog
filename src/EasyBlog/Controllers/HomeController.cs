namespace EasyBlog.Controllers;

public class HomeController(EasyBlogDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index([FromQuery] PostsRequest? request, CancellationToken cancellationToken = default)
    {
        //TODO Add service or similar to improve readability and maintainability, etc
        var postsRequest = request ?? new();

        var posts = await dbContext.Posts.AsNoTracking()
            .Where(x => x.IsPublished)
            .ApplySorting(postsRequest)
            .ApplyPaging(postsRequest)
            .ToListAsync(cancellationToken);

        var postsCount = await dbContext.Posts.AsNoTracking()
            .Where(x => x.IsPublished).CountAsync(cancellationToken);

        var postModels = posts.Select(x => x.ToModel()).ToList();

        var model = new PostsResponse
        {
            Posts = postModels, PageNumber = postsRequest.PageNumber, PageSize = postsRequest.PageSize,
            TotalRecords = postsCount
        };

        return View(model);
    }

    public IActionResult Privacy() => View();
}