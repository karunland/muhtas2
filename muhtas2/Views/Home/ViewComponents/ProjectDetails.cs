using Microsoft.AspNetCore.Mvc;

namespace muhtas2.Views.Home.ViewComponents
{
    public class ProjectDetails : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
