using FootballTeamProject.Infrastructure.Authentication;
using FootballTeamProject.Web.Models;
using FootballTeamProject.Web.Permissions;
using FootballTeamProject.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FootballTeamProject.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email
            }; var rs = await _userManager.CreateAsync(user, model.Password);



            switch (rs.Succeeded)
            {
                case true:
                    TempData["Message"] = "Registration successful";
                    return RedirectToAction("Index", "Home");
                default:
                    ModelState.AddModelError(string.Empty, rs.ToString());
                    return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginUserViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "The email is not correct!");
                return View(model);
            }

            var rs = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            switch (rs.Succeeded)
            {
                case true:
                    TempData["Message"] = "Login Success";
                    return RedirectToAction("Index", "Home");
                default:
                    ModelState.AddModelError(string.Empty, rs.ToString());
                    return View(model);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LogOut(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            TempData["Message"] = "Logout Success";
            return RedirectToAction("Index", "Home");
        }

    }
}
