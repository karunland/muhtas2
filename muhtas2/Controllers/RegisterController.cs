using Entity.DbModel;
using DataAccesss.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace muhtas2.Controllers
{
    [AllowAnonymous]
    public class RegisterController(EfUserDal _userDal) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User person)
        {
            int result = await _userDal.Add(person);
            if (result == 0)
                return RedirectToAction("Index", "Login");
            return BadRequest(result);
        }
    }
}
