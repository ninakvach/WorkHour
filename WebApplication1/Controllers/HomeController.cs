using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            HttpContext.Session.SetString("ProductName", "Mobile");
            return View();
        }

    }
}
