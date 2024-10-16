using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;
using StudentInformationSystem.WEBUI.ViewModels;

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
            ViewBag.UserType = "admin"; //  define the user type of the navbar
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

        public IActionResult ListStudents()
        {
            List<Student> _students = _studentRepository.GetAllT();
            var viewModel = new StudentViewModel
            {
                students = _students
            };
            return View(viewModel);
        }

        public IActionResult ListTeachers()
        {
            List<Teacher> _teachers = _teacherRepository.GetAllT();
            var viewModel = new TeacherViewModel
            {
                teachers = _teachers
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult TeacherDetails(int id)
        {
            return View(_teacherRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult TeacherDetails()
        {
            return View("ListTeachers");
        }

        [HttpGet]
        public IActionResult StudentDetails(int id)
        {
            return View(_studentRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult StudentDetails()
        {
            return View("StudentList");
        }
    }

}
