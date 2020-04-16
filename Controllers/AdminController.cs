using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mariage.Controllers 
{
    [Authorize("AdminOnly")]
    public class AdminController : Controller
    {
        public AdminController()
        {

        }

        
        public IActionResult Index()
        {
            return View();
        }
    }
}