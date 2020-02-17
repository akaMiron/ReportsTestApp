using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reports.Core.Models;
using Reports.Core.Services;
using Reports.Web.Models;

namespace Reports.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICityService _cityService;

        public HomeController(ILogger<HomeController> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }

        public async Task<ActionResult<IEnumerable<City>>> Index()
        {

            var cities = await _cityService.GetAllCities();
            ViewBag.City = cities.Where(x => x.Name == "Kiev").FirstOrDefault().Name;

            return View();
        }

        [Authorize]
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
