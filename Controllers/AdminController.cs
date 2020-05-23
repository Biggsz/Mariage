using System.Linq;
using System.Threading.Tasks;
using Mariage.Data;
using Mariage.Migrations;
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
				Participation? plusOne = null;
				if (model.PlusOneId.HasValue)
				{
					plusOne = await _dbContext.Participations.FindAsync(model.PlusOneId);					
				}

				var participation = new Participation(model.FirstName!, model.LastName!)
				{
					IsInvitedToLunch = model.IsInvitedToLunch,
					CanBringChildren = model.CanBringChildren,
					CanBringPlusOne = model.CanBringPlusOne,
					PlusOne = plusOne
				};

				if (!id.HasValue)
				{
					var user = await _dbContext.Users.Where(u => u.FirstName.ToUpper() == participation.FirstName.ToUpper() && u.LastName.ToUpper() == participation.LastName.ToUpper()).SingleOrDefaultAsync();
					if (user != null)
					{
						participation.UserId = user.Id;
					}
					_dbContext.Participations.Add(participation);
				}
				else
				{
					participation.Id = id.Value;
					_dbContext.Participations.Update(participation);
				}

				if (plusOne != null)
				{
					plusOne.PlusOne = participation;
					_dbContext.Participations.Update(plusOne);
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
		public async Task<IActionResult> SearchParticipations(string search)
		{
			var results = await _dbContext.Participations.Where(p => (p.FirstName.ToUpper() + " " + p.LastName.ToUpper()).Contains(search.ToUpper())).ToListAsync();
			return PartialView(results);
		}

	}
}