using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Services.Interfaces;
using Logic.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusLines.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        
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

        // Dodanie nowego odcinka trasy
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewRouteSection()
        {
            return View();
        }

        // Dodanie nowego odcinka trasy do bazy danych
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewRouteSection(AddRouteSectionViewModel model)
        {
            return View();
        }

        
        // Usunięcie odcinka trasy
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteRouteSection(int routeSectionId)
        {
            return View();
        }

        // Zwraca widok edycji odcinka trasy
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditRouteSection(int routeSectionId)
        {
            return View();
        }

        // Dokonuje edycji odcinka trasy
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditRouteSection(EditRouteSectionViewModel model)
        {
            return View();
        }

        #endregion

        #region Employees
        // Wyświetlenie wszystkich pracowników
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllDrivers()
        {
            return View();
        }

        // Wyświetlenie przejazdów danego kierowcy
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetDriverRides(int employeeId)
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

        // Wyświetlenie szczegółów danego biletu
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetTicketDetails(int ticketId)
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

        // Dodanie nowego przejazdu
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewRide()
        {
            return View();
        }

        // Dodanie nowego przejazdu do bazy danych
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewRide(AddRideViewModel model)
        {
            return View();
        }

        // Usunięcie przejazdu
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteRide(int rideId)
        {
            return View();
        }

        // Zwraca widok edycji przejazdu
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditRide(int rideId)
        {
            return View();
        }

        // Dokonuje edycji przejazdu
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditRide(EditRideViewModel model)
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

        // WYświetlenie wszystkich obecnie niezakończonych zmian (pracowników w pracy)
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUnfinishedShifts()
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
            var models = _adminService.GetAllVehicles();
            return View(models);
        }

        // Dodanie nowego pojazdu
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewVehicle()
        {
            return View();
        }

        // Dodanie nowego pojazdu do bazy danych
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewVehicle(AddVehicleViewModel model)
        {
            _adminService.AddNewVehicle(model);
            return View();
        }

        
        // Usunięcie pojazdu
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteVehicle(int vehicleId)
        {
            _adminService.DeleteVehicle(vehicleId);
            return RedirectToAction("GetAllVehicles");
        }

        // Zwraca widok edycji pojazdu
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditVehicle(int vehicleId)
        {
            var model = _adminService.EditVehicleGet(vehicleId);
            return View(model);
        }

        // Dokonuje edycji pojazdu
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditVehicle(EditVehicleViewModel model)
        {
            _adminService.EditVehiclePost(model);
            return RedirectToAction("GetAllVehicles");
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