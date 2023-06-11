using Entity.DbModel;
using DataAccesss.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace muhtas2.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {

        private readonly IUserDal _userDal;

        public RegisterController(IUserDal userDal)
        {
            _userDal = userDal;
        }

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
