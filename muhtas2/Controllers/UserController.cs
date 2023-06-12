using DataAccesss.Abstract;
using Entity.DbModel;
using Microsoft.AspNetCore.Mvc;

namespace muhtas2.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserDal _userDal;
        private readonly ILoginDal _loginDal;

        public UserController(IUserDal userDal, ILoginDal loginDal)
        {
            _userDal = userDal;
            _loginDal = loginDal;
        }

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
