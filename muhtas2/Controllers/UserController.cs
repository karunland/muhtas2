using Microsoft.AspNetCore.Mvc;

namespace muhtas2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}
