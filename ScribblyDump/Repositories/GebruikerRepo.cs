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
        //changed from genothinbruiker obj, change if necessary
        public void addGebruiker(Gebruiker obj)
        {
            this.context.addGebruiker(obj);
        }

        public bool LoginGebruiker(Gebruiker obj)
        {
           
            return context.loginGebruiker(obj);
            
        }


        public void deleteGebruiker (Gebruiker obj)
        {
            this.context.deleteGebruiker(obj);
        }

        public void Inactief(bool yn)
        {
            this.context.Inactief(yn);
        }

        public void GebrDescr(Gebruiker obj)
        {

        }

    }
}