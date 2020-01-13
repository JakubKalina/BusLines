using AutoMapper;
using Logic.Services.Interfaces;
using Logic.ViewModels.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BusLines.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService __clientService;        

        public ClientController(IClientService clientService)
        {
            __clientService = clientService;
        }


        /// <summary>
        /// Wyświetlenie strony głównej klienta
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Wyświetlenie wszystkich przystanków
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllBusStops()
        {
            var model =  __clientService.GetAllBusStops();
            return View(model);
        }

        /// <summary>
        /// Wyświetlenie wszystkich linii
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllLines()
        {
            var model = __clientService.GetAllLines();
            return View(model);
        }

        /// <summary>
        /// Wyświetlenie wszystkich zaplanowanych przejazdów
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllRides()
        {
            var model = __clientService.GetAllRides();
            return View(model);
        }

        /// <summary>
        /// Wyświetlenie wyszukiwarki przejazdów
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult FindRide()
        {
            return View();
        }

        /// <summary>
        /// Wyszukanie przejazdu o podanych kryteriach
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult FindRide(FindRideViewModel model)
        {
            var rides = __clientService.FindRide(model);

            return View("FoundRides", rides);
        }


    }
}