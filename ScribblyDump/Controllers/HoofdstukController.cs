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

        public ActionResult GoToCreateNewChapter(HoofdstukViewModel H)
        {
            return View("CreateChapter");
        }

        //public ActionResult SubmitChapter(HoofdstukViewModel H)
        //{

        //}
    }
}