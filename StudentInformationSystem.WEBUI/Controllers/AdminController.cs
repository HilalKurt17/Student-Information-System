using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentInformationSystem.WEBUI.Controllers
{
    public class AdminController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.UserType = "admin";
            base.OnActionExecuting(context);
        }
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult NewStudent()
        {
            return View("NewStudent");
        }

        public IActionResult NewTeacher()
        {
            return View("NewTeacher");
        }
    }
}
