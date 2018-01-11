using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScribblyDump.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Scribbly";
            return View();
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is who we are";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }

        public ActionResult GoToLogin()
        {
            return RedirectToAction("GoToLogin", "Gebruiker");
        }

        public ActionResult GoToRegister()
        {
            return RedirectToAction("GoToRegister", "Gebruiker");
        }
    }
}