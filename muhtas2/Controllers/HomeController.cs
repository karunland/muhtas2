using Microsoft.AspNetCore.Mvc;
using muhtas2.Models;
using System.Diagnostics;

namespace muhtas2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}