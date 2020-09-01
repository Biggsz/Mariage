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

		[HttpPost]
		public async Task<IActionResult> Confirm(InvitationViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _dbContext.Users.Include(u => u.Participation).ThenInclude(p => p!.PlusOne).Include(u => u.Participation).ThenInclude(p => p!.PlusOne).SingleOrDefaultAsync(u => u.UserName == User.Identity.Name);
				var participation = user.Participation;
				if (participation != null)
				{
					participation.CompletedForm = true;
					participation.WillAttendDinner = model.WillAttendDinner;
					participation.WillAttendLunch = participation.IsInvitedToLunch ? model.WillAttendLunch : false;
					participation.ChildrenCount = participation.CanBringChildren ? model.Children : 0;
					if ((participation.CanBringPlusOne || participation.PlusOne != null) && model.HasPlusOne)
					{
						Participation? plusOne = null;
						if (participation.PlusOne != null)
						{
							plusOne = participation.PlusOne;
						}
						else if (participation.PlusOne == null && !string.IsNullOrEmpty(model.PlusOneFirstName) && !string.IsNullOrEmpty(model.PlusOneLastName))
						{
							plusOne = new Participation(model.PlusOneFirstName, model.PlusOneLastName);
							plusOne.IsInvitedToLunch = participation.IsInvitedToLunch;
							plusOne.PlusOne = participation;
							participation.PlusOne = plusOne;
						}

						if (plusOne != null)
						{
							plusOne.CompletedForm = true;
							plusOne.WillAttendDinner = model.WillAttendDinner;
							plusOne.WillAttendLunch = plusOne.IsInvitedToLunch ? model.WillAttendLunch : false;
						}

						_dbContext.Update(participation);
						await _dbContext.SaveChangesAsync();
					}
				}
				return RedirectToAction("Invite");
			}
			return View("Invite", model);
		}

		public IActionResult Gift()
		{
			return View();
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Invite()
		{
			var user = await _dbContext.Users.Include(u => u.Participation).ThenInclude(p => p!.PlusOne).SingleOrDefaultAsync(u => u.UserName == User.Identity.Name);
			ViewBag.User = user;
			return View();
		}

	}
}