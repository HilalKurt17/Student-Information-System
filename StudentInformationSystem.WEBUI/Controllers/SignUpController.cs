using Microsoft.AspNetCore.Mvc;

namespace StudentInformationSystem.WEBUI.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
