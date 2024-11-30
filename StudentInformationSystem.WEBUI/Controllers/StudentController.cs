using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;
using StudentInformationSystem.WEBUI.ViewModels;

namespace StudentInformationSystem.WEBUI.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;
        private ITeacherRepository _teacherRepository;
        private ILessonRepository _lessonRepository;
        private IPrivateLessonRepository _privateLessonRepository;
        private IAssignmentRepository _assignmentRepository;
        public StudentController(IStudentRepository studentRepository, ITeacherRepository teacherRepository, ILessonRepository lessonRepository, IPrivateLessonRepository privateLessonRepository, IAssignmentRepository assignmentRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _lessonRepository = lessonRepository;
            _privateLessonRepository = privateLessonRepository;
            _assignmentRepository = assignmentRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.UserType = "student";
            base.OnActionExecuting(context);
        }
        [HttpGet] // show student profile in the index page
        public IActionResult Index()
        {
            int studentID = Convert.ToInt32(Request.Cookies["userID"]);
            Student student = _studentRepository.GetById(studentID)!;
            return View(student);
        }
        // get updated student information from index page and update student
        [HttpPost]
        public IActionResult Index(Student updatedStudent)
        {
            _studentRepository.Update(updatedStudent);
            Student student = _studentRepository.GetById(updatedStudent.StudentID)!;
            return View(student);
        }

        public IActionResult ListLessons() // list all private lessons according to education level of the student
        {
            int studentID = Convert.ToInt32(Request.Cookies["userID"]);
            List<Teacher> allTeachers = _teacherRepository.GetAllT();
            List<LessonDTO> allLessons = _lessonRepository.GetAllT();
            StudentLessonListViewModel model = new StudentLessonListViewModel
            {
                teachers = allTeachers,
                lessons = allLessons,
                student = _studentRepository.GetById(studentID)!
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult LessonDetails(int id) // show lesson details to the student and send request to enroll the course
        {
            StudentTeacher privateLesson = _privateLessonRepository.GetById(id)!;
            return View(privateLesson);
        }

        [HttpPost]
        public IActionResult LessonDetails(StudentTeacher privateLesson)
        {
            int studentID = Convert.ToInt32(Request.Cookies["userID"]);
            privateLesson.StudentID = studentID;
            _privateLessonRepository.NewEnrollment(privateLesson);
            return RedirectToAction("MyLessons");
        }

        [HttpGet]
        public IActionResult MyAssignmentList()
        {
            int studentID = Convert.ToInt32(Request.Cookies["userID"]);
            Student student = _studentRepository.GetById(studentID)!;
            StudentAssignmentListViewModel model = new StudentAssignmentListViewModel()
            {
                assignments = student.Assignments,
                teachers = _teacherRepository.GetAllT(),
                StudentID = studentID,
                privateLessons = _privateLessonRepository.GetAllT()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult MyAssignmentDetails(int id)
        {
            int studentID = Convert.ToInt32(Request.Cookies["userID"]);
            Student student = _studentRepository.GetById(studentID)!;
            StudentAssignmentDetailsViewModel model = new StudentAssignmentDetailsViewModel()
            {
                assignment = student.Assignments.FirstOrDefault(i => i.AssignmentID == id)!,
                teachers = _teacherRepository.GetAllT(),
                studentID = studentID,
                privateLessons = _privateLessonRepository.GetAllT()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MyAssignmentDetails(StudentAssignmentDetailsViewModel model)
        {
            int studentID = Convert.ToInt32(Request.Cookies["userID"]);
            Student student = _studentRepository.GetById(studentID)!;

            if (model.studentAssignmentSolution != null && model.studentAssignmentSolution.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", model.studentAssignmentSolution.FileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.studentAssignmentSolution.CopyToAsync(stream);
                }
                var FileURL = Url.Content($"~/uploads/{model.studentAssignmentSolution.FileName}");
                model.assignment.StudentAssignmentFilePath = FileURL;
            }
            DateTime today = DateTime.Now;
            model.assignment.SubmittedDate = today.Date.ToString("yyyy-MM-dd");
            model.assignment.SubmittedTime = today.TimeOfDay.ToString(@"hh\:mm\:ss");
            _assignmentRepository.SubmitAssignment(model.assignment);
            return RedirectToAction("MyAssignmentList");
        }

        public IActionResult MyLessons()
        {
            int studentID = Convert.ToInt32(Request.Cookies["userID"]);
            Student student = _studentRepository.GetById(studentID)!;
            StudentTeachersViewModel model = new StudentTeachersViewModel
            {
                teachers = _teacherRepository.GetAllT(),
                student = student
            };
            return View(model);
        }
    }
}
