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

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
           
            Repo.addGebruiker(Username, Password);
            return View("Test");
        }





    }
}