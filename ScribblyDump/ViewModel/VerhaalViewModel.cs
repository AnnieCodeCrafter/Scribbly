using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScribblyDump.ViewModel
{
    public class VerhaalViewModel
    {
        private string titel;
        private string beschrijving;
        
        public string Titel
        {
            get { return titel; }
            set { titel = value; }

        }

        public string Beschrijving
        {
            get { return titel; }
            set { beschrijving = value; }
        }
    }
}