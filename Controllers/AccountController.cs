using Mariage.Data;
using Mariage.Models;
using Mariage.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mariage.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<MariageUser> _signInManager;
        private readonly MariageDbContext _dbContext;
        public AccountController(SignInManager<MariageUser> signInManager, MariageDbContext dbContext)
        {
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public IActionResult Login(Uri returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, Uri returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl.ToString());
                }
                else
                {
                    ModelState.AddModelError("Password", "L'email ou le mot de passe n'est pas correct.");
                }
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }


        public IActionResult Register(Uri returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model, Uri returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = new MariageUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };
                var result = await _signInManager.UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var participation = await _dbContext.Participations.SingleOrDefaultAsync(p => p.FirstName.ToUpper() == model.FirstName!.ToUpper() && p.LastName.ToUpper() == model.LastName!.ToUpper());
                    if (participation != null)
                    {
                        user.Participation = participation;
                        await _dbContext.SaveChangesAsync();
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl.ToString());
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Password", error.Description);
                    }
                }
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}