using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScribblyDump.Repositories;
using ScribblyDump.ViewModel;
using System.Data.SqlClient;
using ScribblyDump.Database;
using ScribblyDump.Models;

namespace ScribblyDump.Controllers
{
    public class VerhaalController : Controller
    {

        VerhaalRepo Repo = new VerhaalRepo(new VerhaalSqlContext());
        // GET: Verhaal
        public ActionResult Index()
        {
            //TODO: repo--IEnumerable verhaal
            return View("VerhaalPage");
        }

        public ActionResult GoToAddVerhaal(VerhaalViewModel V)
        {
            return View("CreateVerhaal");

        }

        public ActionResult AddVerhaal(VerhaalViewModel V)
        {
            Verhaal H = new Verhaal()
            
        }





    }
}