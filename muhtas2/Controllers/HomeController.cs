using DataAccesss.EntityFramework;
using Entity.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace muhtas2.Controllers
{
    public class HomeController(EfHomePageDal _homePageDal) : Controller
    {

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _homePageDal.GetHomePageSettings());
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> About()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            return View(await _homePageDal.GetHomePageSettings());
        }

        [HttpPost]
        public async Task<IActionResult> Settings(MonitorShow model)
        {
            var item = await _homePageDal.AddHomePageSettings(model);
            return RedirectToAction("Settings");
        }

    }
}