using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScribblyDump.Models
{
    public class Gebruiker
    {
        private string username;
        private string email;
        private string password;
        private string profilepic;
        private List<Verhaal> tracking;
        private List<Verhaal> written;
        private List<Comment> comment;

        public string Username
        {
            get { return username; }
        }

        public string Email
        {
            get { return email; }
        }

        public string Password
        {
            get { return password; }
        }

        public string Profilepic
        {
            get { return password; }
        }

        public List<Verhaal> Tracking
        {
            get { return tracking; }
        }

        public List<Verhaal> Written
        {
            get { return written; }
        }

        public List<Comment> Comment
        {
            get { return comment; }
        }

        public Gebruiker(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }


    }
}