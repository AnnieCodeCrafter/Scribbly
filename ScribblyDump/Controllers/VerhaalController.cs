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
            //foreach (var item in V.Genres)
            //{

            //    V.genreList.Add(new SelectListItem
            //    {
            //        Text = item.ToString()
            //    });
            //}
            return View("CreateVerhaal", V);

        }

        [HttpPost]
        public ActionResult AddVerhaal(VerhaalViewModel V)
        {
            try
            {
                
                Verhaal B = new Verhaal();
                int id = Convert.ToInt32(Session["usID"]);
                B.VerhaalGenre = (VerhaalGenres)((int)V.Genre);

                Verhaal H = new Verhaal(V.Titel, V.Beschrijving, B.VerhaalGenre, id);
                Repo.AddVerhaal(H);
              

                
                return View("VerhaalPage", H);

               
            }

            

            catch
            {
                return View("Nope");
            }

        }

        public ActionResult GetGenreList(VerhaalViewModel V)
        {
            

            return View();
        }





    }
}