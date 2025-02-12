﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;
using StudentInformationSystem.WEBUI.ViewModels;

namespace StudentInformationSystem.WEBUI.Controllers
{
    [Authorize]
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
            ViewBag.BlockAccess = "0"; // if student has to score any lesson block student access to navbar
            ViewBag.UserType = "student";
            int studentID = Convert.ToInt32(Request.Cookies["userID"]);
            Student student = _studentRepository.GetById(studentID);
            ViewBag.UserFullName = student.Name + " " + student.Surname;
            base.OnActionExecuting(context);
        }
        [HttpGet] // show student profile in the index page
        public IActionResult Index()
        {
            int studentID = Convert.ToInt32(Request.Cookies["userID"]);
            Student student = _studentRepository.GetById(studentID)!;

            foreach (StudentTeacher privateLesson in student.StudentTeachers)
            {
                if (privateLesson.GetScoreComment == true)
                {
                    Teacher teacher = _teacherRepository.GetById(privateLesson.TeacherID)!;
                    GetScoreCommentPLViewModel model = new GetScoreCommentPLViewModel()
                    {
                        student = student,
                        teacherScore = 0,
                        teacher = teacher,
                        privateLessonID = privateLesson.PrivateLessonID
                    };
                    ViewBag.BlockAccess = "1";
                    return View("GetStudentScoreCommentPL", model);
                }
            }
            return View(student);
        }


        [HttpPost] // update private lesson student score and student comment
        public IActionResult GetScoreCommentPL(GetScoreCommentPLViewModel model)
        {
            ViewBag.BlockAccess = "0";
            StudentTeacher privateLesson = _privateLessonRepository.GetAllT().FirstOrDefault(i => i.PrivateLessonID == model.privateLessonID)!;
            Teacher teacher = _teacherRepository.GetById(privateLesson.TeacherID)!;
            if (teacher.TeacherScore == null)
            {
                teacher.TeacherScore = 0;
                teacher.TeacherScore += model.teacherScore * 20;
                teacher.votedStudentsCount += 1;
            }
            else
            {
                teacher.TeacherScore = teacher.TeacherScore * teacher.votedStudentsCount;
                teacher.TeacherScore += model.teacherScore * 20;
                teacher.votedStudentsCount += 1;
                teacher.TeacherScore = teacher.TeacherScore / teacher.votedStudentsCount;
            }
            _privateLessonRepository.Delete(privateLesson.PrivateLessonID);

            _teacherRepository.UpdateTeacherScore(teacher);
            return RedirectToAction("Index");
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

        public IActionResult SignOutSystem()
        {
            Response.Cookies.Delete("userID");
            return RedirectToAction("Index", "Home");
        }
    }
}
