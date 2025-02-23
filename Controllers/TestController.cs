using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Free_Course_For_Student.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Test()
        {
            return View();
        }
        
    }
}