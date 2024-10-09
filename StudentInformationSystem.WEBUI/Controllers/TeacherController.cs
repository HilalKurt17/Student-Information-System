using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentInformationSystem.WEBUI.Controllers
{
    public class TeacherController : Controller
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.UserType = "teacher";
            base.OnActionExecuting(context);
        }
        public IActionResult Index() // home-profile
        {
            return View();
        }

        public IActionResult ListStudents() // list all students 
        {
            return View();
        }

        public IActionResult StudentAssessments() // assign new assessment to the students or view the assigned assessments and grade them
        {
            return View();
        }
    }
}
