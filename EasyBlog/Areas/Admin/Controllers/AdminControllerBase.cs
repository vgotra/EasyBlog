namespace EasyBlog.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = Defaults.Auth.DefaultAdminRoleName)]
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[OutputCache(PolicyName = Defaults.Cache.NoCachePolicy)]
public class AdminControllerBase : Controller;