using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISStudySpot.Models;

namespace ISStudySpot.Controllers
{
    public class HomeController : Controller
    {
        // Home View Controller
        public IActionResult Index()
        {
            return View();
        }

        // Error View Controller
        public IActionResult Error()
        {
            return View();
        }
    }
}
