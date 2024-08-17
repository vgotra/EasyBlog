namespace EasyBlog.Areas.Admin.Controllers;

public class PostsManagementController : AdminControllerBase
{
    public async Task<IActionResult> Index()
    {
        await Task.CompletedTask;
        return View();
    }
}