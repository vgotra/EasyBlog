namespace EasyBlog.Areas.Admin.Controllers;

public class ManagementController : AdminControllerBase
{
    //TODO Add auth, check for custom styles, etc
    public async Task<IActionResult> Index()
    {
        await Task.CompletedTask;
        return View();
    }
}