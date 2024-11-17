﻿using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        IStudentRepository _studentRepository;
        ITeacherRepository _teacherRepository;
        IPasswordRepository _passwordRepository;

        public HomeController(IStudentRepository studentRepository, ITeacherRepository teacherRepository, IPasswordRepository passwordRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _passwordRepository = passwordRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.SignIn = "";
            Passwords model = new Passwords();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignIn(Passwords password)
        {
            List<Teacher> teachers = _teacherRepository.GetAllT();
            List<Passwords> passwords = _passwordRepository.GetAllT();
            foreach (Teacher teacher in teachers)
            {
                if (teacher.Mail == password.userMail)
                {
                    Passwords userPasswordDetails = passwords.FirstOrDefault(i => i.userMail == teacher.Mail)!;
                    if (userPasswordDetails.Password == password.Password)
                    {
                        return RedirectToAction("Index", "Teacher");
                    }

                }
            }
            List<Student> students = _studentRepository.GetAllT();
            foreach (Student student in students)
            {
                if (student.Mail == password.userMail)
                {
                    Passwords userPasswordDetails = passwords.FirstOrDefault(i => i.userMail == student.Mail)!;
                    if (userPasswordDetails.Password == password.userMail)
                    {
                        return RedirectToAction("Index", "Student");
                    }
                }
            }

            if (password.userMail == "hiz.rka389@gmail.com" && password.Password == "1")
            {
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.SignIn = "Failed";
            return View(password);
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.SignUp = "";
            Passwords model = new Passwords();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(Passwords password)
        {
            ViewBag.SignUp = "UnknownMail";
            List<Teacher> teachers = _teacherRepository.GetAllT();
            foreach (Teacher teacher in teachers)
            {
                if (teacher.Mail == password.userMail)
                {
                    _passwordRepository.Add(password);
                    return RedirectToAction("SignIn");
                }
            }
            List<Student> students = _studentRepository.GetAllT();
            foreach (Student student in students)
            {
                if (student.Mail == password.userMail)
                {
                    _passwordRepository.Add(password);
                    return RedirectToAction("SignIn");
                }
            }
            return View(password);
        }
    }
}
