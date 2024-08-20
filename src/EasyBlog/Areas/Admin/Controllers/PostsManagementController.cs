namespace EasyBlog.Areas.Admin.Controllers;

public class PostsManagementController(IPostsManagementService service) : AdminControllerBase
{
    public async Task<IActionResult> Index([FromQuery] PostsInputModel? model, CancellationToken cancellationToken = default)
    {
        var viewModel = await service.GetPostsAsync(model ?? new PostsInputModel(), cancellationToken);
        return View(viewModel);
    }

    public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken = default)
    {
        var post = await service.GetPostByIdAsync(id, cancellationToken);
        if (post == null)
            return NotFound();

        return View(post);
    }

    public IActionResult Create()
    {
        return View(new PostManagementViewModel());
    }

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
        if (post == null)
            return NotFound();

        return View(post);
    }

    [HttpPut]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(PostManagementViewModel model, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await service.UpdatePostAsync(model, cancellationToken);
        if (result)
            return RedirectToAction(nameof(Index));

        ModelState.AddModelError("", "Failed to update the post.");
        return View(model);
    }

    [HttpDelete]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        await service.DeletePostAsync(id, cancellationToken);
        return RedirectToAction(nameof(Index));
    }
}