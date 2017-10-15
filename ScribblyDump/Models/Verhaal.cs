using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScribblyDump.Models
{
    public class Verhaal
    {
        private string titel;
        private string beschrijving;
        private string coverart;
        private List<Hoofdstuk> hoofdstuk;
        private List<Gebruiker> tracker;
        

        public string Titel
        {
            get { return titel; }
        }

        public string Beschrijving
        {
            get { return beschrijving; }
        }

        public string Coverart
        {
            get { return coverart; }
        }

        public List<Hoofdstuk> Hoofdstuk
        {
            get { return hoofdstuk; }
        }

        public List<Gebruiker> Tracker
        {
            get { return tracker; }
        }

        public Verhaal(string titel, string beschrijving, string coverart)
        {
            this.titel = titel;
            this.beschrijving = beschrijving;
            this.coverart = coverart;
   
        }
        
    }
}