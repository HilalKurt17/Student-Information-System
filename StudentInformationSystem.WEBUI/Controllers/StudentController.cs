using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;
        private ITeacherRepository _teacherRepository;
        private ILessonRepository _lessonRepository;
        public StudentController(IStudentRepository studentRepository, ITeacherRepository teacherRepository, ILessonRepository lessonRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _lessonRepository = lessonRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.UserType = "student";
            base.OnActionExecuting(context);
        }
        [HttpGet] // show student profile in the index page
        public IActionResult Index()
        {
            Student student = _studentRepository.GetById(5);
            return View(student);
        }
        // get updated student information from index page and update student
        [HttpPost]
        public IActionResult Index(Student updatedStudent)
        {
            _studentRepository.Update(updatedStudent);
            Student student = _studentRepository.GetById(updatedStudent.StudentID);
            return View(student);
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
