namespace EasyBlog.Areas.Admin.Controllers;

[Area("Admin")]
public class SettingsManagementController : Controller
{
    public async Task<IActionResult> Index()
    {
        await Task.CompletedTask;
        return View();
    }
}