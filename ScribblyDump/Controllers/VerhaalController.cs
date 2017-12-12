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
        public ActionResult Index(VerhaalViewModel V)
        {
           
            int usID = Convert.ToInt32(Session["usID"]);

            List<VerhaalViewModel> F = Repo.ToViewModel(usID);
            //TODO: repo--IEnumerable verhaal
            return View("VerhaalPage", F);
        }

        public ActionResult GoToAddVerhaal(VerhaalViewModel V)
        {
           
            return View("CreateVerhaal", V);

        }

        [HttpPost]
        public ActionResult AddVerhaal(VerhaalViewModel V)
        {
            try
            {
                
                Verhaal B = new Verhaal();
                int usID = Convert.ToInt32(Session["usID"]);
                B.VerhaalGenre = (VerhaalGenres)((int)V.Genre);

                Verhaal J = new Verhaal(V.ID, V.Titel, V.Beschrijving, B.VerhaalGenre, usID);
                Repo.AddVerhaal(J);

                List<VerhaalViewModel> F = Repo.ToViewModel(usID);
              
                return View("VerhaalPage", F);

            }

            catch
            {
                return View("Nope");
            }

        }

        [HttpPost]
       public ActionResult DeleteVerhaal(int id, bool isTrue)
       {
            int usID = Convert.ToInt32(Session["usID"]);

            if (isTrue)
            {
                return View("yup");
            }
            else
            {
                return View("nope");
            }

        }


       
       

    }
}