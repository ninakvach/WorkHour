using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkHour.Business.DataAccess.Abstract;
using WorkHour.Pr.Models;
using WorkHour.Business.SessionStorage;
using Microsoft.AspNetCore.Http;
using Hanssens.Net;

namespace WorkHour.Pr.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult Home(string kullaniciAd, string kullaniciSifre)
        {
           // var message = "This is a much cleaner approach to access Session!";
           // SessionStorage.Current.Session.Set<string>("message", message);
           // HttpContext.Session.SetString("ProductName", "Mobile");
            if (kullaniciAd.Equals("nina") && kullaniciSifre.Equals("1"))
            {

                return View("Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Restore()
        {
            return View();
        }
    }
}
