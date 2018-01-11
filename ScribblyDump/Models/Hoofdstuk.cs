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

        public string VerhaalID { get;  }

        //public Hoofdstuk(string titel, int nummer, string body)
        //{
        //    this.titel = titel;
        //    this.nummer = nummer;
        //    this.body = body;
           
        //}
    }
}