using System.Threading.Tasks;
using Mariage.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mariage.Controllers
{
    [Authorize("AdminOnly")]
    public class AdminController : Controller
    {
        private readonly MariageDbContext _dbContext;

        public AdminController(MariageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Guests()
        {
            var guests = await _dbContext.Participations.ToListAsync();
            return View(guests);
        }
    }
}