namespace EasyBlog.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = Defaults.Auth.DefaultAdminRoleName)]
public class AdminControllerBase : Controller;