﻿using ScribblyDump.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScribblyDump.Repositories;
using ScribblyDump.Interfaces;
using ScribblyDump.Database;
using ScribblyDump.ViewModel;
using System.Data.SqlClient;
using System.Data.Sql;


namespace ScribblyDump.Controllers
{
    public class GebruikerController : Controller
    {

        GebruikerRepo Repo = new GebruikerRepo(new GebruikerSqlContext());
        VerhaalRepo Bepo = new VerhaalRepo(new VerhaalSqlContext());
        // GET: Gebruiker
     

        public ActionResult Index()
        {
            return View();
        }

        //view: index
        public ActionResult GoToRegister()
        {
            return View("Register");
        }

        public ActionResult GoToLogin()
        {
            return View("Login");
        }

        public ActionResult GoToUserPage()
        {
            string username = Session["Username"].ToString();
            Gebruiker F = Repo.GetGebruiker(username);
            GebruikerViewModel obj = new GebruikerViewModel(F.Username, F.Password, F.Email, F.Description);
            return View("userPage", obj);
        }

        //view: register
        [HttpPost]
        public ActionResult Register(GebruikerViewModel obj)
        {
            try
            {
                Gebruiker X = new Gebruiker(obj.Username, obj.Password, obj.Email);
                Repo.addGebruiker(X);
                return View("Login");
            }

            catch (SqlException e)
            {
                return View("Nope");
            }

           
            
        }

        //view: login
        public ActionResult Login(GebruikerViewModel obj)
        {
            
                Gebruiker X = new Gebruiker(obj.Username, obj.Password);
            //Repo.LoginGebruiker(X);
            Gebruiker Y = Repo.LoginGebruiker(X);


                
                if (Y != null)
                {
                    obj = new GebruikerViewModel(Y.Username, Y.Password, Y.Email, Y.Description);
                    // you gotta fill the session before you return the view, or else its bad
                  
                    Session["Username"] = obj.Username;

                    return View("userPage", obj);
                }

                else
                {
                    return View("Nope");
                }
            
            
           

           
           
           
        }
        // view: userpage
        public ActionResult Description(GebruikerViewModel obj)
        {
            string Username = Session["Username"].ToString();
            

          
            Gebruiker Y = Repo.GetGebruiker(Username);     
            obj = new GebruikerViewModel(Y.Username, Y.Password, Y.Email, Y.Description);
            return View("EditUserPage", obj);
        }


        //view: edituserpage       
        public ActionResult UserDescr(GebruikerViewModel obj)
        {            
            string username = Session["Username"].ToString();
            Gebruiker G = new Gebruiker(username);
            Repo.SetGebrDescr(username, obj.Description);
            Gebruiker F = Repo.GetGebruiker(username);
            obj = new GebruikerViewModel(F.Username, F.Password, F.Email, F.Description);
            
            
            

            return View("userPage", obj);
        }

        //view: userpage

        public ActionResult GoToStory(GebruikerViewModel obj)
        {
            string username = Session["Username"].ToString();

            int usID = Repo.getGebruikerID(username);
            if(usID != 0)
            {
                Session["usID"] = usID;
                
                return RedirectToAction("index", "verhaal");

            }

            else
            {
               
                return View("Nope");
            }
           

        }

        public ActionResult GoToShortlist(GebruikerViewModel obj)
        {
            string username = Session["Username"].ToString();

            int usID = Repo.getGebruikerID(username);
            if (usID != 0)
            {
                Session["usID"] = usID;

                return RedirectToAction("Shortlist", "verhaal");

            }

            else
            {

                return View("Nope");
            }

        }




    }
}