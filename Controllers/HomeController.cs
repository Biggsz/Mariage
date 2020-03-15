using System.Threading.Tasks;
using Mariage.Data;
using Mariage.Models;
using Mariage.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mariage.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<MariageUser> _userManager;
        private readonly MariageDbContext _dbContext;

        public HomeController(UserManager<MariageUser> userManager, MariageDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Info()
        {
            var user = await _dbContext.Users.Include(u => u.Participation).SingleOrDefaultAsync(u => u.UserName == User.Identity.Name);
            ViewBag.User = user;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Info(InvitationViewModel model)
        {
            var user = await _dbContext.Users.Include(u => u.Participation).SingleOrDefaultAsync(u => u.UserName == User.Identity.Name);
            ViewBag.User = user;
            return View(model);
        }

    }
}