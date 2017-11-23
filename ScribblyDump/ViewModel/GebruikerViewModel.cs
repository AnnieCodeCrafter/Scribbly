using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScribblyDump.ViewModel
{
    public class GebruikerViewModel
    {
        private string username;
        private string email;
        private string password;
        private string description;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        

        public GebruikerViewModel(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }
        
        public GebruikerViewModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public GebruikerViewModel(string username, string password, string email, string description)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.description = description;


        }

        public GebruikerViewModel()
        {

        }


        
    }
}