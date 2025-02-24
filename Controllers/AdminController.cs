using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EXE_PROJECT.Models;
using Free_Course_For_Student.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Free_Course_For_Student.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepo;
        private readonly IModuleRepository _moduleRepository;
        private readonly ISubmissionRepository _submissionRepository;

        public AdminController(IUserRepository userRepository, ICourseRepository courseRepo, IModuleRepository moduleRepository, ISubmissionRepository submissionRepository)
        {
            _userRepository = userRepository;
            _courseRepo = courseRepo;
            _moduleRepository = moduleRepository;
            _submissionRepository = submissionRepository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet("user-management")]
        public IActionResult UserManagement()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Index", "Home");
            }
            var users = _userRepository.GetAllUser();
            return View(users);
        }

        [HttpGet("course-management")]
        public IActionResult CourseManagement()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Index", "Home");
            }
            var courses = _courseRepo.GetAllCourse();
            return View(courses);
        }

        [HttpPost("course/save")]
        public IActionResult SaveCourse(Course course)
        {
            if (course.Id == 0)
            {
                _courseRepo.AddCourse(course);
            }
            else
            {
                _courseRepo.UpdateCourse(course);
            }
            return RedirectToAction("CourseManagement");
        }

        [HttpPost("course/delete/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            _courseRepo.DeleteCourse(id);
            return RedirectToAction("CourseManagement");
        }

        [HttpGet("submission-management")]
        public IActionResult SubmissionManagement()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Index", "Home");
            }
            var submissions = _submissionRepository.GetAllSubmissions(); // Lấy hết từ DB
            return View(submissions);
        }

        // 🟢 Xóa Submission
        [HttpPost("delete-submission/{submissionId}")]
        public IActionResult DeleteSubmission(int submissionId)
        {
            _submissionRepository.Delete(submissionId);
            return RedirectToAction("SubmissionManagement");
        }

        [HttpPost("update-submission")]
        public IActionResult UpdateSubmission([FromBody] Submission submission)
        {
            var existingSubmission = _submissionRepository.GetById(submission.SubmissionId);
            if (existingSubmission != null)
            {
                existingSubmission.Score = submission.Score;
                if (submission.Status == "Approved") // Nếu admin duyệt bài
                {
                    existingSubmission.Status = "Approved";
                }
                _submissionRepository.Update(existingSubmission);
            }
            return Ok();
        }


        [HttpPost("approve-submission/{submissionId}")]
        public IActionResult ApproveSubmission(int submissionId)
        {
            var submission = _submissionRepository.GetById(submissionId);
            if (submission != null)
            {
                submission.Status = "Approved"; // Cập nhật trạng thái
                _submissionRepository.Update(submission);
            }
            return Ok();
        }



        // 🟢 Lấy danh sách module theo CourseId
        [HttpGet("module-management/{courseId}")]
        public IActionResult ModuleManagement(int courseId)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Index", "Home");
            }
            var modules = _moduleRepository.GetModuleListbycourseid(courseId);
            ViewBag.CourseId = courseId;
            return View(modules);
        }

        // 🟢 Thêm hoặc cập nhật module
        [HttpPost("save-module")]
        public IActionResult SaveModule(Module module)
        {
            if (module.ModuleId == 0)
            {
                _moduleRepository.Add(module);
            }
            else
            {
                _moduleRepository.Update(module);
            }
            return RedirectToAction("ModuleManagement", new { courseId = module.CourseId });
        }

        // 🟢 Xóa module
        [HttpPost("delete-module/{moduleId}")]
        public IActionResult DeleteModule(int moduleId)
        {
            var module = _moduleRepository.GetById(moduleId);
            if (module != null)
            {
                _moduleRepository.Delete(moduleId);
            }
            return RedirectToAction("ModuleManagement", new { courseId = module.CourseId });
        }

        public bool IsAdmin()
        {
            string role = HttpContext.Session.GetString("Role");
            if (role == "admin")
            {
                return true;
            }
            return false;
        }
    }
}