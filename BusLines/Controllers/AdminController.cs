using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusLines.Controllers
{
    public class AdminController : Controller
    {
        #region BusLines
        // Wyświetlenie wszystkich linii autobusowych
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllBusLines()
        {
            return View();
        }

        // Dodanie nowej linii autobusowej - wyświetlenie formularza
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewBusLine()
        {
            return View();
        }

        // Dodanie nowej linii autobusowej do bazy danych
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewBusLine(AddBusLineViewModel model)
        {
            return View();
        }

        // Usunięcie linii autobusowej
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBusLine(int busLineId)
        {
            return View();
        }

        // Zwraca widok edycji linii autobusowej
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditBusLine(int busLineId)
        {
            return View();
        }

        // Dokonuje edycji linii autobusowej
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditBusLine(EditBusLineViewModel model)
        {
            return View();
        }

        #endregion

        #region  BusStops

        // Wyświetlenie wszystkich przystanków autobusowych 
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllBusStops()
        {
            return View();
        }

        // Dodanie nowego przystanku autobusowego
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewBusStops()
        {
            return View();
        }

        // Dodanie nowego przystanku autobusowego do bazy danych
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewBusStop(AddBusStopViewModel model)
        {
            return View();
        }

        
        // Usunięcie przystanku autobusowego
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBusStop(int busStopId)
        {
            return View();
        }

        // Zwraca widok edycji przystanku autobusowego
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditBusStop(int busStopId)
        {
            return View();
        }

        // Dokonuje edycji przystanku autobusowego
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditBusStop(EditBusStopViewModel model)
        {
            return View();
        }

        #endregion


        #region  RouteSections

        // Wyświetlenie wszystkich odcinków tras
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllRouteSections()
        {
            return View();
        }

        #endregion

        #region Employees
        // Wyświetlenie wszystkich pracowników
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllEmployees()
        {
            return View();
        }

        #endregion

        #region Tickets
        // Wyświetlenie wszystkich zakupionych biletów
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllTickets()
        {
            return View();
        }
        #endregion

        #region  Rides
        // Wyświetlenie wszystkich przejazdów   
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllRides()
        {
            return View();
        }
        #endregion

        #region Shifts
        // Wyświetlenie wszystkich zmian kierowców
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllShifts()
        {
            return View();
        }
        #endregion

        #region Vehicles
        // Wyświetlenie wszystkich pojazdów
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllVehicles()
        {
            return View();
        }
        #endregion

        #region VisitedBusStops
        // Wyświetlenie wszystkich odwiedzonych przystanków
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllVisitedBusStops()
        {
            return View();
        }
        #endregion

    
    }
}