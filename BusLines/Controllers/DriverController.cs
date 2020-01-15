using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BusLines.Controllers
{
    public class DriverController : Controller
    {
        public IActionResult BeginNewShift()
        {
            return View();
        }

        public IActionResult EndShift()
        {
            return View();
        }
    }
}