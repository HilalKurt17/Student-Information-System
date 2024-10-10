using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentInformationSystem.Data.Abstract;

namespace StudentInformationSystem.WEBUI.Controllers
{

    public class AdminController : Controller
    {
        private IStudentRepository _studentRepository;
        private ITeacherRepository _teacherRepository;

        // get student and teacher repositories using Dependency Injection method
        public AdminController(IStudentRepository studentRepository,
            ITeacherRepository teacherRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }
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
