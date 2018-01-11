using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScribblyDump.ViewModel
{
    public class HoofdstukViewModel
    {
        public string Titel { get; set; }
        public int nummer { get; set; }

        public string Body { get; set; }

        public int hfdstkID { get; set; }

        public int VerhaalID { get; set; }

        public HoofdstukViewModel(string titel, string body, int nummer, int verhaalID)
        {
            this.Titel = titel;
            this.Body = body;
            this.nummer = nummer;
            this.VerhaalID = VerhaalID;
        }

        public HoofdstukViewModel()
        {

        }
    }
}