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

            List<VerhaalViewModel> F = Repo.ToListViewModel(Repo.GetListVerhalen(usID));
         
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
                int usID = Convert.ToInt32(Session["usID"]);
             
                Verhaal J = new Verhaal(V.ID, V.Titel, V.Beschrijving, (VerhaalGenres)((int)V.Genre), usID);
                Repo.AddVerhaal(J);

                List<VerhaalViewModel> F = Repo.ToListViewModel(Repo.GetListVerhalen(usID));
              
                return View("VerhaalPage", F);

            }

            catch
            {
                return View("Nope");
            }

        }

        
        public ActionResult Delete(int id) 
        {

            if (id > 0)
            {

                Repo.DeleteVerhaal(Repo.GetVerhaal(id));
                int usID = Convert.ToInt32(Session["usID"]);
                List<VerhaalViewModel> F = Repo.ToListViewModel(Repo.GetListVerhalen(usID));

                return View("VerhaalPage", F);


            }

            else
            {
                return View("Nope");
            }
                //return RedirectToAction("DeleteVerhaal");
          
        }

        public ActionResult CreateNewChapter(int id)
        {
            Session["StoryID"] = id;
            return RedirectToAction("GoToCreateNewChapter", "hoofdstuk");
            
            
        }

        public ActionResult FirstChapter(int id)
        {
            Session["StoryID"] = id;
            return RedirectToAction("ViewChapterList", "hoofdstuk");
        }

        public ActionResult Shortlist()
        {
            int usID = Convert.ToInt32(Session["usID"]);
            List<VerhaalViewModel> F = Repo.ShortlistProcedure(usID);
            
            return View("ShortlistVerhaal", F);
        }

        public ActionResult GoToBrowse(VerhaalViewModel L)
        {
           
            List<VerhaalViewModel> F = Repo.ToListViewModel(Repo.GetAlleVerhalen());

            return View("AllStories", F);

        }

        
       
        





    }
}