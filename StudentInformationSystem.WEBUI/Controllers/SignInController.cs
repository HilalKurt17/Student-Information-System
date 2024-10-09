using Microsoft.AspNetCore.Mvc;

namespace StudentInformationSystem.WEBUI.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
