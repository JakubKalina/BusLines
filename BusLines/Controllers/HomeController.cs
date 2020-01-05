using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data.UnitOfWork;
using System.Threading.Tasks;

namespace BusLines.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
            // To działa !
            //return RedirectToAction("Login", "Account");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
