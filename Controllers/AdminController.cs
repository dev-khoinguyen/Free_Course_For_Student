using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Free_Course_For_Student.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index() { return View(); }

        [HttpGet("user-management")]
        public IActionResult UserManagement() { return View(); }

        [HttpGet("course-management")]
        public IActionResult CourseManagement() { return View(); }
        [HttpGet("submission-management")]
        public IActionResult SubmissionManagement() { return View(); }

        [HttpGet("module-management")]
        public IActionResult ModuleManagement() { return View(); }

    }
}