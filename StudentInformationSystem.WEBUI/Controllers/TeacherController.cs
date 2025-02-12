﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;
using StudentInformationSystem.WEBUI.ViewModels;

namespace StudentInformationSystem.WEBUI.Controllers
{
    [Authorize]
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
            int teacherID = Convert.ToInt32(Request.Cookies["userID"]);
            Teacher _teacher = _teacherRepository.GetById(teacherID)!;

            ViewBag.userFullName = _teacher.Name + " " + _teacher.Surname;
            ViewBag.userApproved = _teacher.IsApproved;
            ViewBag.UserType = "teacher"; // define user type for navbar
            base.OnActionExecuting(context);
        }

        public IActionResult GettingStarted()
        {
            return View();
        }

        public IActionResult Index() // home-profile get teacher information by teacher id
        {
            int teacherID = Convert.ToInt32(Request.Cookies["userID"]);
            Teacher _teacher = _teacherRepository.GetById(teacherID)!;
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
            int teacherID = Convert.ToInt32(Request.Cookies["userID"]);
            StudentTeacher privateLesson = new StudentTeacher();
            LessonDetailsViewModel model = new LessonDetailsViewModel
            {
                allLessons = _lessonRepository.GetAllT(),
                teacher = _teacherRepository.GetById(teacherID)!,
                privateLessonDetails = privateLesson

            };
            return View(model);
        }

        // create new private lesson
        [HttpPost]
        public IActionResult CreateLesson(LessonDetailsViewModel newPrivateLesson)
        {
            int teacherID = Convert.ToInt32(Request.Cookies["userID"]);
            Teacher _teacher = _teacherRepository.GetById(teacherID)!;
            newPrivateLesson.privateLessonDetails.TeacherID = _teacher.TeacherID;
            _privateLessonRepository.Add(newPrivateLesson.privateLessonDetails);
            StudentTeacher pLesson = _privateLessonRepository.GetById(newPrivateLesson.privateLessonDetails.PrivateLessonID)!;
            return RedirectToAction("LessonList");
        }

        // list all private lessons
        public IActionResult LessonList()
        {
            int teacherID = Convert.ToInt32(Request.Cookies["userID"]);
            Teacher teacher = _teacherRepository.GetById(teacherID)!;
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
            DateTime now = DateTime.Now;
            DateTime DateNow = now.Date;
            TimeSpan TimeNow = now.TimeOfDay;
            if (updatedLesson.privateLessonDetails.RemoveLesson == true)
            {
                _privateLessonRepository.Delete(updatedLesson.privateLessonDetails.PrivateLessonID); // delete the lesson
            }
            else if ((Convert.ToDateTime(updatedLesson.privateLessonDetails.LessonEndDate) < DateNow) || (Convert.ToDateTime(updatedLesson.privateLessonDetails.LessonEndDate) == DateNow && TimeSpan.Parse(updatedLesson.privateLessonDetails.LessonEndTime) <= TimeNow))
            {
                updatedLesson.privateLessonDetails.GetScoreComment = true;
                _privateLessonRepository.Update(updatedLesson.privateLessonDetails);
            }
            else
            {
                _privateLessonRepository.Update(updatedLesson.privateLessonDetails); // update the lesson
            }

            return RedirectToAction("LessonList");
        }

        public IActionResult PrivateLessonStudentList() // list all students 
        {
            int teacherID = Convert.ToInt32(Request.Cookies["userID"]);
            Teacher teacher = _teacherRepository.GetById(teacherID)!;
            List<int> studentIDs = new List<int>();
            foreach (StudentTeacher privateLesson in teacher.StudentTeachers)
            {
                if ((privateLesson.StudentID != null) && !(studentIDs.Contains((int)privateLesson.StudentID!)))
                {
                    studentIDs.Add((int)privateLesson.StudentID!);
                }

            };


            TeacherAssignmentListViewModel model = new TeacherAssignmentListViewModel()
            {
                teacherID = teacherID,
                students = _studentRepository.GetSelectedStudents(studentIDs),
                privateLessons = _privateLessonRepository.GetAllT(),
                assignments = teacher.Assignments
            };
            return View(model);
        }

        public IActionResult PLSDetails(int id) // private lesson - student details 
        {
            StudentTeacher privateLesson = _privateLessonRepository.GetById(id)!;
            Student student = _studentRepository.GetById((int)privateLesson.StudentID!)!;
            List<Assignment> assignments = student.Assignments.FindAll(i => i.privateLessonID == privateLesson.PrivateLessonID);
            PLSDetailsViewModel model = new PLSDetailsViewModel
            {
                student = student,
                assignments = assignments,
                privateLesson = privateLesson

            };
            return View(model);
        }

        [HttpGet]
        public IActionResult NewAssignment() // create new assignment to the students 
        {
            int teacherID = Convert.ToInt32(Request.Cookies["userID"]);
            TeacherAssignmentViewModel model = new TeacherAssignmentViewModel
            {
                teacher = _teacherRepository.GetById(teacherID),
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
            return RedirectToAction("AssignmentList");
        }

        public IActionResult AssignmentList()
        {
            int teacherID = Convert.ToInt32(Request.Cookies["userID"]);
            Teacher teacher = _teacherRepository.GetById(teacherID)!;
            List<int> studentIDs = new List<int>();
            foreach (StudentTeacher privateLesson in teacher.StudentTeachers)
            {
                if ((privateLesson.StudentID != null) && !(studentIDs.Contains((int)privateLesson.StudentID!)))
                {
                    studentIDs.Add((int)privateLesson.StudentID!);
                }

            };


            TeacherAssignmentListViewModel model = new TeacherAssignmentListViewModel()
            {
                teacherID = teacherID,
                students = _studentRepository.GetSelectedStudents(studentIDs),
                privateLessons = _privateLessonRepository.GetAllT(),
                assignments = teacher.Assignments
            };
            return View(model);
        } // show all assignments as a list 

        [HttpGet]
        public IActionResult AssignmentDetails(int id)
        {
            int teacherID = Convert.ToInt32(Request.Cookies["userID"]);
            Teacher teacher = _teacherRepository.GetById(teacherID)!;
            TeacherAssignmentViewModel model = new TeacherAssignmentViewModel()
            {
                assignment = teacher.Assignments.FirstOrDefault(i => i.AssignmentID == id),
                teacher = teacher,
                students = _studentRepository.GetAllT(),
                deleteAssignment = false
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignmentDetails(TeacherAssignmentViewModel model)
        {
            if (model.deleteAssignment == true)
            {
                _assignmentRepository.Delete(model.assignment.AssignmentID);
            }
            else if (model.assignment.IsCompleted == true)
            {
                DateTime today = DateTime.Now;
                model.assignment!.UpdatedDate = today.Date.ToString("yyyy-MM-dd");
                model.assignment.UpdatedTime = today.TimeOfDay.ToString(@"hh\:mm");
                _assignmentRepository.GradeAssignment(model.assignment);
            }
            else
            {
                if (model.TeacherAssignmentFile != null && model.TeacherAssignmentFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", model.TeacherAssignmentFile.FileName);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.TeacherAssignmentFile.CopyToAsync(stream);
                    }
                    var FileURL = Url.Content($"~/uploads/{model.TeacherAssignmentFile.FileName}");
                    model.assignment!.TeacherAssignmentFilePath = FileURL.ToString();
                }
                DateTime today = DateTime.Now;
                model.assignment!.UpdatedDate = today.Date.ToString("yyyy-MM-dd");
                model.assignment.UpdatedTime = today.TimeOfDay.ToString(@"hh\:mm");

                _assignmentRepository.Update(model.assignment);
            }
            return RedirectToAction("AssignmentList");
        }

        [HttpGet]
        public IActionResult PrivateLessonDetails(int id)
        {
            return View();
        }
        public IActionResult SignOutSystem()
        {
            Response.Cookies.Delete("userID");
            return RedirectToAction("Index", "Home");
        }
    }
}
