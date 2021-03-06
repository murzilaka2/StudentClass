using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentClass.Data;
using StudentClass.Data.Helpers;
using StudentClass.Data.Interfaces;
using StudentClass.Data.Models;
using StudentClass.ViewModels.UserPass;
using System.Security.Claims;

namespace StudentClass.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUser users;
        private readonly ApplicationContext dbContext;

        public HomeController(IUser users, ApplicationContext dbContext)
        {
            this.users = users;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsEmailExist(string email)
        {
            if (email.Equals("admin@gmail.com"))
            {
                return Json(true);
            }
            return Json(true);
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) { return Redirect("/Account"); }

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var claims = users.getClaims(model);
                if (claims != null)
                {
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims));
                    return Redirect("/Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Not correct password");
                }

            }

            return View(model);

        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var newSalt = SecurityHelper.GenerateSalt(43);
                var newHash = SecurityHelper.HashPassword(model.Pass, newSalt, 58, 43);

                User user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    HashPassword = newHash,
                    Salt = newSalt
                };
                dbContext.Add(user);
                dbContext.SaveChanges();
                var newModel = new LoginViewModel { Email = model.Email, Pass = model.Pass };
                var newClaim = users.getClaims(newModel);
                if (newClaim != null)
                {
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(newClaim));
                    return Redirect("/Account");
                }

            }
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}
