using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LINQ101MVC.Models;

namespace LINQ101MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db = ApplicationDbContext.Create();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
        }
    }
}