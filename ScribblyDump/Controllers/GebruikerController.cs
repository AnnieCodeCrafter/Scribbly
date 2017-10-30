using ScribblyDump.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScribblyDump.Repositories;
using ScribblyDump.Interfaces;
using ScribblyDump.Database;

namespace ScribblyDump.Controllers
{
    public class GebruikerController : Controller
    {

        GebruikerRepo Repo = new GebruikerRepo(new GebruikerSqlContext());
        // GET: Gebruiker
        public ActionResult Index()
        {
            
            return View();
           
        }

        public ActionResult GoToRegister()
        {
            return View("Register");
        }

        public ActionResult GoToLogin()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Register(string Username, string Password, string Email)
        {           
            Repo.addGebruiker(Username, Password, Email);
            return View("Login");
        }

        public ActionResult Login(string Username, string Password)
        {
            if (Repo.LoginGebruiker(Username, Password) == true)
            {

                
                return View("userPage");

            }

            else
            {
                return View("Nope");
            }
           
           
        }





    }
}