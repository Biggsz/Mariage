using Microsoft.AspNetCore.Mvc;

namespace Mariage
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}