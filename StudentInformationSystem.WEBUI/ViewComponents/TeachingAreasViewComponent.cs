using Microsoft.AspNetCore.Mvc;

namespace StudentInformationSystem.WEBUI.ViewComponents
{
    public class TeachingAreasViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
