using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScribblyDump.Models
{
    public class Hoofdstuk
    {
        private string titel;
        private int nummer;
        private string body;
        private List<Comment> comment;

        public string Titel
        {
            get { return titel; }
        }

        public int Nummer
        {
            get { return nummer; }
        }

        public string Body
        {
            get { return body; }
        }

        public List<Comment> Comment
        {
            get { return comment; }
        }

        public int VerhaalID { get;  }

        public int HoofdstukID { get; }

        public Hoofdstuk(string titel, string body, int nummer, int verhaalid, int hoofdstukID)
        {
            this.titel = titel;
            this.nummer = nummer;
            this.body = body;
            this.VerhaalID = verhaalid;
            this.HoofdstukID = hoofdstukID;

        }

        public Hoofdstuk(string titel, string body, int nummer, int verhaalid)
        {
            this.titel = titel;
            this.nummer = nummer;
            this.body = body;
            this.VerhaalID = verhaalid;
        }

        public Hoofdstuk()
        {

        }
    }
}