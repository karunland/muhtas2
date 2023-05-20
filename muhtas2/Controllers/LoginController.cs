using DataAccesss.Concrete;
using Entity.DbModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Operations;
using System.Security.Claims;

namespace muhtas2.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public static List<User> writers = new List<User>
        {
            new User
            {
                FirstName = "admin",
                LastName = "developer",
                Mail = "deneme@gmail.com",
                Password = "password",
                isAdmin = true
            }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User p)
        {
            User user = writers.Where(x => x.Mail == p.Mail && x.Password == p.Password).FirstOrDefault();
            if (user == null)
                return NotFound();

            var claims = new List<Claim> {
                    new Claim (ClaimTypes.Name, user.Mail)
            };

            var userIdentity = new ClaimsIdentity(claims, "a");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);

            HttpContext.Session.SetString("Name", user.Mail);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, Route("Logout/")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
