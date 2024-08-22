namespace EasyBlog.Areas.Admin.Controllers;

public class ManagementController : AdminControllerBase
{
    public async Task<IActionResult> Index()
    {
        return await Task.FromResult(View());
    }
}