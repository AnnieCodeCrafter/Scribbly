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
        // TODO: change back to .obj

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
        public ActionResult Register(Gebruiker obj)
        {
                
            var keys = Request.Form.AllKeys;            
            string username = Request.Form.Get(keys[0]);
            string password = Request.Form.Get(keys[1]);
            string email = Request.Form.Get(keys[2]);

            // obj = new Gebruiker(Username, Email, Password);
            obj = new Gebruiker(username, password, email);
            Repo.addGebruiker(obj);
            return View("Login");
        }

        public ActionResult Login(Gebruiker obj)
        {
            var keys = Request.Form.AllKeys;
            string username = Request.Form.Get(keys[0]);
            string password = Request.Form.Get(keys[1]);
            obj = new Gebruiker(username, password);
            if (Repo.LoginGebruiker(obj) == true)
            {

                
                return View("userPage");

            }

            else
            {
                return View("Nope");
            }
           
           
        }

        public ActionResult Description(Gebruiker obj)
        {
            


            return View("userPage");
        }





    }
}