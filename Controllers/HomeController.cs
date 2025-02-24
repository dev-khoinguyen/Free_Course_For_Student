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
        private readonly IModuleRepository _moduleRepository;
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly ISubmissionRepository _submissionRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, ICourseRepository courseRepository, IModuleRepository moduleRepository, IUserCourseRepository userCourseRepository, ISubmissionRepository submissionRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _courseRepository = courseRepository;
            _moduleRepository = moduleRepository;
            _userCourseRepository = userCourseRepository;
            _submissionRepository = submissionRepository;
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
            if (!IsLogin())
            {
                return RedirectToAction("Login", "Home"); // Nếu chưa đăng nhập, quay về Login
            }
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
            // Kiểm tra session có tồn tại không
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (!IsLogin())
            {
                return RedirectToAction("Login", "Home"); // Nếu chưa đăng nhập, quay về Login
            }

            // Lấy thông tin User từ database
            var user = _userRepository.GetUserById(userId.Value);

            if (user == null)
            {
                return RedirectToAction("Login", "Home"); // Nếu không tìm thấy user, yêu cầu đăng nhập lại
            }

            return View(user); // Truyền user vào View để hiển thị
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
                HttpContext.Session.SetString("Role", user.Role);
                if (user.Role == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home"); // Chuyển hướng sau khi đăng nhập thành công
                }
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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Xóa toàn bộ session
            return RedirectToAction("Login", "Home"); // Chuyển về trang đăng nhập
        }

        [HttpGet]
        public IActionResult CourseInformation(int id)
        {

            if (!IsLogin())
            {
                return RedirectToAction("Login", "Home");
            }

            var user = HttpContext.Session.GetInt32("UserId");
            var validate = _userCourseRepository.IsJoin(id, user);
            if (validate)
            {
                ViewBag.isJoin = true;
            }
            else
            {
                ViewBag.isJoin = false;
            }
            var course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public IActionResult JoinCourse(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            _userCourseRepository.AddUserCourse(userId, id);
            return RedirectToAction("CourseInformation", new { id = id });
        }



        [HttpGet]
        public IActionResult AllModule(int id)
        {
            if (!IsLogin())
            {
                return RedirectToAction("Login", "Home"); // Nếu chưa đăng nhập, quay về Login
            }
            var module = _moduleRepository.GetAvaiModule(id);
            return View(module);
        }

        [HttpGet]
        public IActionResult ModuleInformation(int id)
        {
            if (!IsLogin())
            {
                return RedirectToAction("Login", "Home"); // Nếu chưa đăng nhập, quay về Login
            }
            var module = _moduleRepository.GetById(id);
            return View(module);
        }
        public IActionResult ClientProfile()
        {
            if (!IsLogin())
            {
                return RedirectToAction("Login", "Home"); // Nếu chưa đăng nhập, quay về Login
            }
            return View();
        }

        public bool IsLogin()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return false;
            }
            return true;
        }
        [HttpGet]
        public IActionResult ClientSubmission(int itemid)
        {
            if (!IsLogin())
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.ModuleId = itemid;
            return View();
        }

        [HttpPost]
        public IActionResult ClientSubmission(int itemid, string submissionUrl)
        {
            ViewBag.ModuleId = itemid;
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (!IsLogin() || userId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (string.IsNullOrWhiteSpace(submissionUrl))
            {
                ModelState.AddModelError("", "Vui lòng nhập URL hợp lệ.");
                ViewBag.ModuleId = itemid;
                return View();
            }

            // Kiểm tra nếu đã nộp bài
            bool isSubmitted = _submissionRepository.IsSubmiss(userId, itemid);
            if (isSubmitted)
            {
                TempData["ErrorMessage"] = "Bạn đã nộp bài cho module này!";
                return View();
            }

            // Tạo mới Submission
            var submission = new Submission
            {
                UserId = userId.Value,
                ModuleId = itemid,
                SubmissionUrl = submissionUrl,
                Score = 0, // Mặc định 0 điểm
                Status = "Pending", // Chờ duyệt
                SubmittedAt = DateTime.Now
            };

            _submissionRepository.Add(submission);
            TempData["SuccessMessage"] = "Nộp bài thành công!";
            return View();
        }
    }
}
