using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkHour.Business;
using WorkHour.Data.Models;

namespace WorkHour.Controllers
{
    public class WorkController : Controller
    {
        // GET: Work
        public ActionResult Index()
        {
            WorkBusinessLayer workBusinessLayer = new WorkBusinessLayer();
            List<Work> employees = workBusinessLayer.Works.ToList();
            return View(employees);

        }
    }
}