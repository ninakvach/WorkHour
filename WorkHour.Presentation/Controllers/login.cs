using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WorkHour.Presentation.Controllers
{
    public class login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
