using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScribblyDump.Controllers;
using ScribblyDump.Database;
using ScribblyDump.Interfaces;
using ScribblyDump.Models;

namespace ScribblyDump.Repositories
{
    public class GebruikerRepo
    {
        IGebruiker context;

        public GebruikerRepo(IGebruiker context)
        {
            this.context = context;
        }
        //changed from gebruiker obj, change if necessary
        public void addGebruiker(string Username, string Password, string Email)
        {
            this.context.addGebruiker(Username, Password, Email);
        }

        public bool LoginGebruiker(string Username, string Password)
        {
           
            return context.loginGebruiker(Username, Password);
            
        }


        public void deleteGebruiker (Gebruiker obj)
        {
            this.context.deleteGebruiker(obj);
        }

        public void Inactief(bool yn)
        {
            this.context.Inactief(yn);
        }

    }
}