using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BusLines.Controllers
{
    public class DriverController : Controller
    {
        // Rozpoczęcie nowej zmiany z aktualną datą i czasem
        [HttpPost]
        public IActionResult BeginNewShift()
        {
            return View();
        }

        // Zakończenie zmiany z aktualną datą i czasem
        public IActionResult EndShift()
        {
            return View();
        }
    }
}