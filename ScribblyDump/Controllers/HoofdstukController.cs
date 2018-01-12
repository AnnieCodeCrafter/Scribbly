using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScribblyDump.Database;
using ScribblyDump.Models;
using ScribblyDump.ViewModel;
using ScribblyDump.Repositories;


namespace ScribblyDump.Controllers
{
    public class HoofdstukController : Controller
    {
        // GET: Hoofdstuk
        HoofdstukRepo Repo = new HoofdstukRepo(new HoofdstukSqlContext());
        public ActionResult Index(HoofdstukViewModel H)
        {
            return View("Hoofdstuk");
        }

        public ActionResult GoToCreateNewChapter()
        {
            return View("CreateChapter");
        }

        public ActionResult SubmitChapter(HoofdstukViewModel H)
        {
            string Titel = H.Titel;
            string Body = H.Body;
            int Nummer = Convert.ToInt32(H.nummer);
            int storyID = Convert.ToInt32(Session["StoryID"]);
            Hoofdstuk D = new Hoofdstuk(Titel, Body, Nummer, storyID);
            Repo.AddHoofdstuk(D);

            return RedirectToAction("Index", "Verhaal");
        }

        public ActionResult ViewChapterList()
        {
            
            int StoryID = Convert.ToInt32(Session["StoryID"]);
        

           List<HoofdstukViewModel> F = Repo.ToListViewModel(Repo.GetHoofdstuk(StoryID));

            return View("Hoofdstuk", F);
        }

        public ActionResult ViewChapter(int ID)
        {
            int StoryID = Convert.ToInt32(Session["StoryID"]);

            HoofdstukViewModel H = Repo.ToViewModel(Repo.getSingleHoofdstuk(ID, StoryID));

            return View("SingleChapter", H);

        }
    }
}