namespace EasyBlog.Areas.Admin.Controllers;

[Area("Admin")]
public class ManagementController : Controller
{
    //TODO Add auth, check for custom styles, etc
    public async Task<IActionResult> Index()
    {
        await Task.CompletedTask;
        return View();
    }
}