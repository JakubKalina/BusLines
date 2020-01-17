using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusLines.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        // Zwraca widok wszystkich dotychczasowych zmian kierowcy
        [HttpGet]
        [Authorize(Roles = "Kierowca")]
        public async Task<IActionResult> ShowDriverShifts()
        { 
            var shifts = await _driverService.ShowDriverShitfs(HttpContext.User.Identity.Name);
            return View(shifts);
        }

        // Rozpoczęcie nowej zmiany z aktualną datą i czasem
        [HttpPost]
        [Authorize(Roles = "Kierowca")]
        public IActionResult BeginNewShift()
        {
            return View();
        }

        // Zakończenie zmiany z aktualną datą i czasem
        [HttpPost]
        [Authorize(Roles = "Kierowca")]
        public IActionResult EndShift()
        {
            return View();
        }
    }
}