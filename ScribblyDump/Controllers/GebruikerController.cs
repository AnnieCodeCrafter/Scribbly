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
            obj = Repo.LoginGebruiker(new Gebruiker(username, password));
            if (obj != null)
            {
                // you gotta fill the session before you return the view, or else its bad
                Session["Message"] = "yey";
                Session["Username"] = username;
                return View("userPage", obj);

            }

            else
            {
                return View("Nope");
            }
           
           
        }

        public ActionResult Description(Gebruiker obj)
        {
            string Username = Session["Username"].ToString();
            obj = Repo.GetGebruiker(new Gebruiker(Username));

            return View("EditUserPage", obj);
        }       
    

        public ActionResult UserDescr(string username, string description)
        {

            
            username = Session["Username"].ToString() ;
            var keys = Request.Form.AllKeys;
            string Descr = Request.Form.Get(keys[0]);

            Repo.SetGebrDescr(username, description);

            return View();
        }




    }
}