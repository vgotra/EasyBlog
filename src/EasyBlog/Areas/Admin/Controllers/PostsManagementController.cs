namespace EasyBlog.Areas.Admin.Controllers;

[Area("Admin")]
public class PostsManagementController : Controller
{
    public async Task<IActionResult> Index()
    {
        await Task.CompletedTask;
        return View();
    }
}