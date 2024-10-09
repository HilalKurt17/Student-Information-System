using Microsoft.AspNetCore.Mvc;

namespace StudentInformationSystem.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
