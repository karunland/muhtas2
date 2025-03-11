using DataAccesss.EntityFramework;
using Entity.DbModel;
using Microsoft.AspNetCore.Mvc;

namespace muhtas2.Controllers
{
    public class UserController(EfUserDal _userDal, EfLoginDal _loginDal) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var item = _loginDal.GetLoginUser();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(User Model)
        {
            var result = await _userDal.Add(Model);
            return View();
        }
    }
}
