using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScribblyDump.Models
{
    //TODO: update class diagram enum 
    public enum VerhaalGenres
    {
        sliceoflife, adventure, drama, tragedy, comedy, sciencefiction, fantasy, horror, romance, crossover, mystery
    }

    public class Verhaal
    {
        private string titel;
        private string beschrijving;
        private string coverart;
        private int auteurid;
        private List<Hoofdstuk> hoofdstuk;
        private List<Gebruiker> tracker;

        public  VerhaalGenres VerhaalGenre { get; set; }
        

        public string Titel
        {
            get { return titel; }
        }

        public int AuteurID
        {
            get { return auteurid; }
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

        //public Verhaal(string titel, string beschrijving, string coverart)
        //{
        //    this.titel = titel;
        //    this.beschrijving = beschrijving;
        //    this.coverart = coverart;
   
        //}

        public Verhaal(string titel, string beschrijving, VerhaalGenres genre, int auteurID)
        {
            this.titel = titel;
            this.beschrijving = beschrijving;
            this.auteurid = auteurID;
            this.VerhaalGenre = genre;
        }
        
        public Verhaal()
        {

        }
    }
}