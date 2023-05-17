using Entity.DbModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                    new Claim (ClaimTypes.Name, user.FirstName)
            };

            var userIdentity = new ClaimsIdentity(claims, "a");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);

            HttpContext.Session.SetString("username", user.FirstName);
            return RedirectToAction("Index", "Home");
        }
    }
}
