using Microsoft.AspNetCore.Mvc;

public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
