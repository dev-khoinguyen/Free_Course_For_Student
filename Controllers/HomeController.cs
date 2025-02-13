using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EXE_PROJECT.Models;
using Free_Course_For_Student.Repository.Interface;
using Microsoft.AspNetCore.Http;

namespace EXE_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, ICourseRepository courseRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Certification()
        {
            return View();
        }
        public IActionResult TrainingIndustry()
        {
            return View();
        }
        public IActionResult LeaningMaterials()
        {
            var course = _courseRepository.GetAllCourse();
            return View(course);
        }
        public IActionResult News()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Information()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _userRepository.Login(username, password);

            if (user != null)
            {
                // Lưu thông tin user vào session
                HttpContext.Session.SetString("UserName", user.Username);
                HttpContext.Session.SetInt32("UserId", user.Id);

                return RedirectToAction("Index", "Home"); // Chuyển hướng sau khi đăng nhập thành công
            }
            else
            {
                ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Trả lại form nếu có lỗi
            }
            _userRepository.AddUser(model); // Thêm trực tiếp vào DB
            return RedirectToAction("Login", "Home"); // Hiển thị thông báo đơn giản
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UploadResource()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Xóa toàn bộ session
            return RedirectToAction("Login", "Home"); // Chuyển về trang đăng nhập
        }

    }
}
