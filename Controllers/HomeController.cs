using System.Threading.Tasks;
using Mariage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mariage.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<MariageUser> _userManager;

        public HomeController(UserManager<MariageUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Info()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }
    }
}