﻿using ScribblyDump.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScribblyDump.Controllers
{
    public class GebruikerController : Controller
    {
        // GET: Gebruiker
        public ActionResult Index()
        {
            
            
           
            return View();
           
        }

        public ActionResult Redirecty()
        {
            return View("Test");
        }

       


    }
}