using Microsoft.AspNetCore.Mvc;

namespace muhtas2.Views.Home.ViewComponents
{
    public class Devices : ViewComponent
    {
        [HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
