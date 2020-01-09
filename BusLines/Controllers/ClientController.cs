using AutoMapper;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusLines.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService __clientService;        

        public ClientController(IClientService clientService)
        {
            __clientService = clientService;
        }


        // Wyświetlenie strony głównej klienta
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        // Wyświetlenie wszystkich przystanków
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllBusStops()
        {
            var model =  __clientService.GetAllBusStops();
            return View(model);
        }

        // Wyświetlenie wszystkich linii
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllLines()
        {
            var model = __clientService.GetAllLines();
            return View(model);
        }

        // Wyświetlenie wszystkich zaplanowanych przejazdów
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllRides()
        {
            var model = __clientService.GetAllRides();
            return View(model);
        }


    }
}