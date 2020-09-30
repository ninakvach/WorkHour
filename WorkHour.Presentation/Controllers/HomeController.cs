using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkHour.Business.DataAccess.Abstract;
using WorkHour.Presentation.Models;

namespace WorkHour.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IUnitofWork _unit;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUnitofWork _unit , ILogger<HomeController> logger)
        {
            this._unit = _unit;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
