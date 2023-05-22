using DataAccesss.Abstract;
using DataAccesss.Concrete;
using Entity.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using muhtas2.Models;
using System.Diagnostics;

namespace muhtas2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomePageDal _homePageDal;
        public HomeController(IHomePageDal homePageDal)
        {
            _homePageDal = homePageDal;
        }
        
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