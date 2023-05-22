using DataAccesss.Abstract;
using DataAccesss.Concrete;
using DataAccesss.Validations;
using Entity.DbModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Operations;
using System.Security.Claims;
using ZstdSharp.Unsafe;

namespace muhtas2.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUserDal _userDal;
        public LoginController(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            int result = await _userDal.IsUser(user);
            
            LoginValidation uv = new LoginValidation();
            ValidationResult results = uv.Validate(user);

            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            if (result == 1)
                return NotFound();

            var claims = new List<Claim> {
                    new Claim (ClaimTypes.Name, user.Mail)
            };

            var userIdentity = new ClaimsIdentity(claims, "MuhtasAuthType");
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

            return Ok();
        }
    }
}
