using System.Threading.Tasks;
using Mariage.Data;
using Mariage.Models;
using Mariage.ViewModels;
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

        [HttpPost]
        public async Task<IActionResult> UpdateGuest(int? id, EditGuestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var participation = new Participation(model.FirstName, model.LastName)
                {
                    IsInvitedToLunch = model.IsInvitedToLunch,
                    CanBringChildren = model.CanBringChildren,
                    CanBringPlusOne = model.CanBringPlusOne
                };

                if (!id.HasValue)
                {
                    _dbContext.Participations.Add(participation);
                }
                else
                {
                    participation.Id = id.Value;
                    _dbContext.Participations.Update(participation);
                }

                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Guests");
            }
            return View("EditGuest", model);
        }
        public async Task<IActionResult> DeleteGuest(int id) 
        {
            var participation = await _dbContext.Participations.FindAsync(id);
            _dbContext.Participations.Remove(participation);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Guests");
        }

        public async Task<IActionResult> EditGuest(int id)
        {
            var participation = await _dbContext.Participations.FindAsync(id);
            var model = new EditGuestViewModel
            {
                Id = participation.Id,
                FirstName = participation.FirstName,
                LastName = participation.LastName,
                IsInvitedToLunch = participation.IsInvitedToLunch,
                CanBringChildren = participation.CanBringChildren,
                CanBringPlusOne = participation.CanBringPlusOne
            };
            return PartialView("EditGuest", model);
        }

        public IActionResult AddGuest()
        {
            return PartialView("EditGuest");
        }
    }
}