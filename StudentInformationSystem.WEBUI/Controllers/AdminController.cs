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

        // index page of the admin
        public IActionResult Index()
        {
            return View("Index");
        }
        // add new student page of the admin
        public IActionResult NewStudent()
        {
            Student viewModel = new Student();
            return View("NewStudent", viewModel);
        }

        // get new student information and add it to the student repository
        [HttpPost]
        public IActionResult NewStudent(Student newStudent)
        {
            _studentRepository.Add(newStudent);
            return RedirectToAction("ListStudents");
        }

        public IActionResult NewTeacher()
        {
            return View("NewTeacher");
        }

        // list all students in the student information system to the admin
        public IActionResult ListStudents()
        {
            List<Student> _students = _studentRepository.GetAllT();
            var viewModel = new StudentViewModel
            {
                students = _students
            };
            return View(viewModel);
        }

        // list all teachers in the student information system to the admin
        public IActionResult ListTeachers()
        {
            List<Teacher> _teachers = _teacherRepository.GetAllT();
            var viewModel = new TeacherViewModel
            {
                teachers = _teachers
            };
            return View(viewModel);
        }

        // show selected teacher information in detail to the admin
        [HttpGet]
        public IActionResult TeacherDetails(int id)
        {

            return View(_teacherRepository.GetById(id));
        }

        // update selected teacher information
        [HttpPost]
        public IActionResult TeacherDetails()
        {
            return RedirectToAction("ListTeachers");
        }

        // show selected student information in detail
        [HttpGet]
        public IActionResult StudentDetails(int id)
        {
            return View(_studentRepository.GetById(id));
        }

        // update selected student information
        [HttpPost]
        public IActionResult StudentDetails()
        {
            return View("StudentList");
        }
    }

}
