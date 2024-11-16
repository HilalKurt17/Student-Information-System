using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;
using StudentInformationSystem.WEBUI.ViewModels;

namespace StudentInformationSystem.WEBUI.Controllers
{
    public class TeacherController : Controller
    {
        IStudentRepository _studentRepository;
        ITeacherRepository _teacherRepository;
        ILessonRepository _lessonRepository;
        IPrivateLessonRepository _privateLessonRepository;
        IAssignmentRepository _assignmentRepository;

        // implement repositories using dependency injection
        public TeacherController(IStudentRepository studentRepository, ITeacherRepository teacherRepository, ILessonRepository lessonRepository, IPrivateLessonRepository privateLessonRepository, IAssignmentRepository assignmentRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _lessonRepository = lessonRepository;
            _privateLessonRepository = privateLessonRepository;
            _assignmentRepository = assignmentRepository;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.UserType = "teacher"; // define user type for navbar
            base.OnActionExecuting(context);
        }
        public IActionResult Index() // home-profile get teacher information by teacher id
        {

            Teacher _teacher = _teacherRepository.GetById(17)!;
            List<LessonDTO> _lessons = _lessonRepository.GetAllT();
            TeacherDetailsViewModel teacherDetails = new TeacherDetailsViewModel
            {
                teacher = _teacher,
                lessons = _lessons
            };
            return View(teacherDetails);
        }

        // update teacher information 
        [HttpPost]
        public async Task<IActionResult> Index(TeacherDetailsViewModel updatedTeacherDetails)
        {
            // after teacher CV and Reference letter is approved, teacher cannot add new reference letter or CV
            if (updatedTeacherDetails.teacher.IsApproved != true)
            {
                if (updatedTeacherDetails.CVFile != null && updatedTeacherDetails.CVFile.Length > 0)
                {
                    // copy the cv file in the wwwroot/uploads folder
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", updatedTeacherDetails.CVFile.FileName);
                    // if a file with the same name exists, delete existing file
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    // add new file to the "wwwroot/uploads" directory
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updatedTeacherDetails.CVFile.CopyToAsync(stream);
                    }

                    // save CV url in the teacher CVFilePath property
                    var CVFileUrl = Url.Content($"~/uploads/{updatedTeacherDetails.CVFile.FileName}");
                    updatedTeacherDetails.teacher.CVFilePath = CVFileUrl.ToString();
                }
                if (updatedTeacherDetails.ReferenceLetterFile != null && updatedTeacherDetails.ReferenceLetterFile.Length > 0)
                {
                    // copy the reference letter file in the wwwroot/uploads folder
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads",
                        updatedTeacherDetails.ReferenceLetterFile.FileName);
                    // if a file with the same name exists, delete it
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    // copy the reference letter file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updatedTeacherDetails.ReferenceLetterFile.CopyToAsync(stream);
                    }
                    // save Reference letter file url
                    var ReferenceLetterFileUrl = Url.Content($"~/uploads/{updatedTeacherDetails.ReferenceLetterFile.FileName}");
                    updatedTeacherDetails.teacher.References[0].ReferenceLetterFilePath = ReferenceLetterFileUrl.ToString();
                }
            }
            _teacherRepository.Update(updatedTeacherDetails.teacher);

            TeacherDetailsViewModel model = new TeacherDetailsViewModel
            {
                lessons = _lessonRepository.GetAllT(),
                teacher = _teacherRepository.GetById(updatedTeacherDetails.teacher.TeacherID)!
            };

            return View("Index", model);


        }
        // new private lesson creation page
        public IActionResult CreateLesson()
        {
            StudentTeacher privateLesson = new StudentTeacher();
            LessonDetailsViewModel model = new LessonDetailsViewModel
            {
                allLessons = _lessonRepository.GetAllT(),
                teacher = _teacherRepository.GetById(17)!,
                privateLessonDetails = privateLesson

            };
            return View(model);
        }

        // create new private lesson
        [HttpPost]
        public IActionResult CreateLesson(LessonDetailsViewModel newPrivateLesson)
        {
            int ID = 17;
            Teacher _teacher = _teacherRepository.GetById(ID)!;
            newPrivateLesson.privateLessonDetails.TeacherID = _teacher.TeacherID;
            _privateLessonRepository.Add(newPrivateLesson.privateLessonDetails);
            StudentTeacher pLesson = _privateLessonRepository.GetById(newPrivateLesson.privateLessonDetails.PrivateLessonID)!;
            return RedirectToAction("LessonList");
        }

        // list all private lessons
        public IActionResult LessonList()
        {
            int id = 17;
            Teacher teacher = _teacherRepository.GetById(id)!;
            List<StudentTeacher> privateLessons = teacher.StudentTeachers;
            return View(privateLessons);
        }

        // show lesson details
        public IActionResult LessonDetails(int id)
        {
            StudentTeacher? lessonDetails = _privateLessonRepository.GetById(id);
            List<LessonDTO> allLessonsList = _lessonRepository.GetAllT();
            Teacher teacher = _teacherRepository.GetById(lessonDetails!.TeacherID)!;
            Student student;
            if (lessonDetails.StudentID != null)
            {
                student = _studentRepository.GetById((int)lessonDetails.StudentID)!;
            }
            else
            {
                student = new Student();
            }

            LessonDetailsViewModel model = new LessonDetailsViewModel
            {
                allLessons = allLessonsList,
                privateLessonDetails = lessonDetails,
                teacher = teacher,
                student = student
            };
            return View(model);
        }


        // update lesson details
        [HttpPost]
        public IActionResult LessonDetails(LessonDetailsViewModel updatedLesson)
        {
            if (updatedLesson.privateLessonDetails.RemoveLesson == true)
            {
                _privateLessonRepository.Delete(updatedLesson.privateLessonDetails.PrivateLessonID); // delete the lesson
            }
            else
            {
                _privateLessonRepository.Update(updatedLesson.privateLessonDetails); // update the lesson
            }

            return RedirectToAction("LessonList");
        }

        public IActionResult ListStudents() // list all students 
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewAssignment() // create new assignment to the students 
        {
            TeacherAssignmentViewModel model = new TeacherAssignmentViewModel
            {
                teacher = _teacherRepository.GetById(17),
                students = _studentRepository.GetAllT(),
                assignment = new Assignment()
            };
            return View("StudentAssignments", model);
        }

        [HttpPost] // save the assignment
        public async Task<IActionResult> NewAssignment(TeacherAssignmentViewModel newAssignment)
        {
            if (newAssignment.TeacherAssignmentFile != null && newAssignment.TeacherAssignmentFile.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", newAssignment.TeacherAssignmentFile.FileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await newAssignment.TeacherAssignmentFile.CopyToAsync(stream);
                }
                var FileURL = Url.Content($"~/uploads/{newAssignment.TeacherAssignmentFile.FileName}");
                newAssignment.assignment!.TeacherAssignmentFilePath = FileURL.ToString();
            }
            DateTime today = DateTime.Now;
            newAssignment.assignment.CreatedDate = today.Date.ToString("yyyy-MM-dd");
            newAssignment.assignment.CreatedTime = today.TimeOfDay.ToString(@"hh\:mm\:ss");
            _assignmentRepository.Add(newAssignment.assignment);
            return View("AssignmentList");
        }
    }
}
