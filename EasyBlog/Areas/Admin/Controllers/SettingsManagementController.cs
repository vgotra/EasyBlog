namespace EasyBlog.Areas.Admin.Controllers;

public class SettingsManagementController : AdminControllerBase
{
    public async Task<IActionResult> Index()
    {
        return await Task.FromResult(View());
    }
}