using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScribblyDump.ViewModel
{
    public enum genre
    {
        sliceoflife, adventure, drama, tragedy, comedy, sciencefiction, fantasy, horror, romance, crossover, mystery
    }
    public class VerhaalViewModel
    {
        private string titel;
        private string beschrijving;
        private int gebrID;
        
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

        public int GebrID
        {
            get { return gebrID; }
            set { gebrID = value; }

        }
        public VerhaalViewModel(string titel, string beschrijving, genre genre, int gebrID)
        {
            this.titel = titel;
            this.beschrijving = beschrijving;
            this.genre = genre;
            this.gebrID = gebrID;
        }
    }
}