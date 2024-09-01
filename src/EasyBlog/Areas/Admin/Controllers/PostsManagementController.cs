namespace EasyBlog.Areas.Admin.Controllers;

public class PostsManagementController(IPostsManagementService service, ILogger<PostsManagementController> logger) : AdminControllerBase
{
    public async Task<IActionResult> Index([FromQuery] PostsInputModel? model, CancellationToken cancellationToken = default)
    {
        var inputModel = model ?? new PostsInputModel();
        var viewModel = await service.GetPostsAsync(inputModel, cancellationToken);
        return View(viewModel);
    }

    public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken = default)
    {
        var post = await service.GetPostByIdAsync(id, cancellationToken);
        return post == null ? NotFound() : View(post);
    }

    public IActionResult Create() => View(new PostManagementViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PostManagementViewModel model, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
            return View(model);

        await service.CreatePostAsync(model, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken = default)
    {
        var post = await service.GetPostByIdAsync(id, cancellationToken);
        return post == null ? NotFound() : View(post);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(PostManagementViewModel model, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
            return View(model);

        try
        {
            await service.UpdatePostAsync(model, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Exception during update of post");
            ModelState.AddModelError("", "Failed to update the post.");
            return View(model);
        }
    }

    [HttpDelete]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        await service.DeletePostAsync(id, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    /// Temporary
    public new IActionResult NotFound() => RedirectToAction(nameof(Index));
}