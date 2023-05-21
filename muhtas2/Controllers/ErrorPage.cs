using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace muhtas2.Controllers
{
    [Route("/[controller]")]
    public class ErrorPage : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
