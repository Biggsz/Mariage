using Mariage.Models;
using Mariage.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mariage.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<MariageUser> _signInManager;
        public AccountController(SignInManager<MariageUser> signInManager)
        {
            _signInManager = signInManager;
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
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                var result = await _signInManager.UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
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