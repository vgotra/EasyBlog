namespace EasyBlog.Areas.Admin.Controllers;

public class SettingsManagementController : AdminControllerBase
{
    public async Task<IActionResult> Index()
    {
        await Task.CompletedTask;
        return View();
    }
}