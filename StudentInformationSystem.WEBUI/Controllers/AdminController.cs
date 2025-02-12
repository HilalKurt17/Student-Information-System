﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;
using StudentInformationSystem.WEBUI.ViewModels;

namespace StudentInformationSystem.WEBUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IStudentRepository _studentRepository;
        private ITeacherRepository _teacherRepository;
        private ILessonRepository _lessonRepository;
        private List<LessonDTO> _lessonDTOList;

        // get student and teacher repositories using Dependency Injection method
        public AdminController(IStudentRepository studentRepository,
            ITeacherRepository teacherRepository, ILessonRepository lessonRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _lessonRepository = lessonRepository;
            _lessonDTOList = _lessonRepository.GetAllT();
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
        // add new teacher page of the admin
        public IActionResult NewTeacher()
        {
            TeacherDetailsViewModel teacherDetails = new TeacherDetailsViewModel
            {
                teacher = new Teacher()
            };
            return View("NewTeacher", teacherDetails);
        }
        // get new teacher information and add it to the teacher repository
        [HttpPost]
        public IActionResult NewTeacher(TeacherDetailsViewModel newTeacher)
        {
            _teacherRepository.Add(newTeacher.teacher);

            return RedirectToAction("ListTeachers");
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
                lessons = _lessonDTOList,
                teachers = _teachers
            };
            return View(viewModel);
        }

        // show selected teacher information in detail to the admin
        [HttpGet]
        public IActionResult TeacherDetails(int id)
        {
            Teacher teacher = _teacherRepository.GetById(id);
            TeacherDetailsViewModel teacherDetails = new TeacherDetailsViewModel
            {
                teacher = teacher,
                lessons = _lessonDTOList
            };
            return View(teacherDetails);
        }

        // update selected teacher information
        [HttpPost]
        public async Task<IActionResult> TeacherDetails(TeacherDetailsViewModel updatedTeacher)
        {

            if (updatedTeacher.teacher.UnenrollmentState == true)
            {
                _teacherRepository.Delete(updatedTeacher.teacher.TeacherID);
            }
            else if (updatedTeacher.teacher.IsApproved == true)
            {
                _teacherRepository.ConfirmTeacher(updatedTeacher.teacher);
            }


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
        public IActionResult StudentDetails(Student student)
        {
            if (student.UnenrollmentState == true)
            {
                _studentRepository.Delete(student.StudentID);
            }
            return RedirectToAction("ListStudents");
        }

        public IActionResult SignOutSystem()
        {
            Response.Cookies.Delete("userID");
            return RedirectToAction("Index", "Home");
        }
    }

}
