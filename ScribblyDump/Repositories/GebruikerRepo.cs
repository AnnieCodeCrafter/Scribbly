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
       
        public void addGebruiker(Gebruiker obj)
        {
            this.context.addGebruiker(obj);
        }

        public Gebruiker LoginGebruiker(Gebruiker obj)
        {
           
            return context.loginGebruiker(obj);
            
        }

        public void SetGebrDescr(string username, string descr)
        {
            this.context.SetGebrDescr(username, descr);
        }

        public Gebruiker GetGebruiker(Gebruiker obj)
        {
            return context.getGebruiker(obj);
        }

        public int getGebruikerID(string username)
        {
            return context.GetGebruikerID(username);
        }
    }
}