using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Wypozyczalnia1.Models;

namespace Wypozyczalnia1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var vehicles = new List<VehicleItemViewModel>
            {
                new VehicleItemViewModel { Id = 1, Name = "Cross", ImageUrl = "/images/cross.jpg" },
                new VehicleItemViewModel { Id = 2, Name = "Heckler - miejski", ImageUrl = "/images/heckler.jpg" },
                new VehicleItemViewModel { Id = 3, Name = "Trek - Górski", ImageUrl = "/images/trek.jpg" }
            };

            return View(vehicles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
