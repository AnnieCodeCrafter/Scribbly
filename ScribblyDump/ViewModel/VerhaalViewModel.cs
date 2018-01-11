using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        private genre genre;
        
        public string Titel
        {
            get { return titel; }
            set { titel = value; }

        }

        public IEnumerable<SelectListItem> Genres
        {
            get; set;
        }
       
        public int ID { get; set; }
        public genre Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public string Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }

        public int GebrID
        {
            get { return gebrID; }
            set { gebrID = value; }

        }
        public VerhaalViewModel(int id, string titel, string beschrijving, genre genre, int gebrID)
        {
            this.titel = titel;
            this.beschrijving = beschrijving;
            this.genre = genre;
            this.gebrID = gebrID;
            this.ID = id;
        }

        public VerhaalViewModel()
        {

        }

        public VerhaalViewModel(string titel)
        {
            this.titel = titel;
        }

        
        
    }

        
    
}