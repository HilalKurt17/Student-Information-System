using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentInformationSystem.WEBUI.Controllers
{
    public class StudentController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.UserType = "student";
            base.OnActionExecuting(context);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListTeachers()
        {
            return View();
        }

        public IActionResult MyAssessments()
        {
            return View();
        }

        public IActionResult MyLessons()
        {
            return View();
        }
    }
}
