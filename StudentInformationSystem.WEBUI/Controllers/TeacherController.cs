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
        public TeacherController(IStudentRepository studentRepository, ITeacherRepository teacherRepository, ILessonRepository lessonRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _lessonRepository = lessonRepository;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.UserType = "teacher";
            base.OnActionExecuting(context);
        }
        public IActionResult Index() // home-profile get teacher information by teacher id
        {
            Teacher _teacher = _teacherRepository.GetById(0);
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
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads",
                        updatedTeacherDetails.CVFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updatedTeacherDetails.CVFile.CopyToAsync(stream);
                    }
                    var CVFileUrl = Url.Content($"~/uploads/{updatedTeacherDetails.CVFile.FileName}");
                    updatedTeacherDetails.teacher.CVFilePath = CVFileUrl.ToString();
                }
                if (updatedTeacherDetails.ReferenceLetterFile != null && updatedTeacherDetails.ReferenceLetterFile.Length > 0)
                {
                    // copy the reference letter file in the wwwroot/uploads folder
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads",
                        updatedTeacherDetails.ReferenceLetterFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updatedTeacherDetails.ReferenceLetterFile.CopyToAsync(stream);
                    }
                    var ReferenceLetterFileUrl = Url.Content($"~/uploads/{updatedTeacherDetails.ReferenceLetterFile.FileName}");
                    updatedTeacherDetails.teacher.References[0].ReferenceLetterFilePath = ReferenceLetterFileUrl.ToString();
                }
            }
            _teacherRepository.Update(updatedTeacherDetails.teacher);

            return View("Index");


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
