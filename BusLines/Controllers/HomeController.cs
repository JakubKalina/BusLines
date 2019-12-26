using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data.UnitOfWork;

namespace BusLines.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var allEmployees = _unitOfWork.EmployeesRepository.GetAll();
            var allShitfs = _unitOfWork.ShiftsRepository.GetAll();
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
