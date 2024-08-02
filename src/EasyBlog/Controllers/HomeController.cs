namespace EasyBlog.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Privacy() => View();
}