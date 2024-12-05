using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;
using StudentInformationSystem.WEBUI.ViewModels;
using System.Security.Claims;

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

        public IActionResult UnauthorizedUser()
        {
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ReturnToHome()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.SignIn = "";
            SignInViewModel model = new SignInViewModel()
            {
                password = "",
                mail = ""
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {

            Passwords password = new Passwords()
            {
                Password = model.password,
                userMail = model.mail
            };
            List<Teacher> teachers = _teacherRepository.GetAllT();
            List<Passwords> passwords = _passwordRepository.GetAllT();
            foreach (Teacher teacher in teachers)
            {
                if (teacher.Mail == password.userMail)
                {
                    Passwords userPasswordDetails = passwords.FirstOrDefault(i => i.userMail == teacher.Mail)!;
                    if (userPasswordDetails != null && userPasswordDetails.Password == password.Password)
                    {
                        AddUserInfoToCookies(teacher.TeacherID);
                        // add claims for user authentication
                        var claims = new List<Claim>
                        {
                            new Claim("userID", teacher.TeacherID.ToString())
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, "userID");
                        await HttpContext.SignInAsync("userID", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
                        });
                        return RedirectToAction("Index", "Teacher");
                    }

                }
            }
            List<Student> students = _studentRepository.GetAllT();
            foreach (Student student in students)
            {
                if (student.Mail == password.userMail)
                {
                    Passwords? userPasswordDetails = passwords.FirstOrDefault(i => i.userMail == student.Mail);

                    if (userPasswordDetails != null && userPasswordDetails.Password == password.Password)
                    {
                        AddUserInfoToCookies(student.StudentID);
                        // add claims for user authentication
                        var claims = new List<Claim>
                        {
                            new Claim("userID", student.StudentID.ToString())
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, "userID");
                        await HttpContext.SignInAsync("userID", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
                        });
                        return RedirectToAction("Index", "Student");
                    }
                }
            }

            if (password.userMail == "hiz.rka389@gmail.com" && password.Password == "1")
            {
                AddUserInfoToCookies(0); // use 0 as admin ID
                                         // add claims for user authentication
                var claims = new List<Claim>
                        {
                            new Claim("userID", "0")
                        };
                var claimsIdentity = new ClaimsIdentity(claims, "userID");
                await HttpContext.SignInAsync("userID", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
                });
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.SignIn = "Failed";
            return View(model);
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.SignUp = "";
            SignInViewModel model = new SignInViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(SignInViewModel model)
        {
            Passwords password = new Passwords()
            {
                Password = model.password,
                userMail = model.mail
            };

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
            ViewBag.SignUp = "UnknownMail";
            return View(model);
        }

        public void AddUserInfoToCookies(int userID) // get user ID using Cookies
        {
            var options = new CookieOptions
            {
                SameSite = SameSiteMode.None,
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true,
                Secure = true

            };

            Response.Cookies.Append("userID", userID.ToString(), options);

        }
    }
}
