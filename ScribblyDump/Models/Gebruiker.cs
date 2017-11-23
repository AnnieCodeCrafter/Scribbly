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
        private string description;
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
            get { return profilepic; }
        }

        public List<Verhaal> Tracking
        {
            get { return tracking; }
        }

        public List<Verhaal> Written
        {
            get { return written; }
        }

        public string Description
        {
            get { return description; }
        }

        public List<Comment> Comment
        {
            get { return comment; }
        }

        public Gebruiker(string username, string password, string email)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }

        public Gebruiker(string username)
        {
            this.username = username;

        }

        public Gebruiker(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Gebruiker(string username, string password, string email, string desc, string profilePic)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.description = desc;
            this.profilepic = profilePic;
        }
        public Gebruiker()
        {
           

        }

    }
}