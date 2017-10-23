using ScribblyDump.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScribblyDump.Models;

namespace ScribblyDump.Database
{
    public class GebruikerSqlContext : DatabaseConnection, IGebruiker
    {
        public void addGebruiker(Gebruiker obj)
        {
            throw new NotImplementedException();
        }

        public void deleteGebruiker(Gebruiker obj)
        {
            throw new NotImplementedException();
        }

        public bool Inactief(bool yn)
        {
            throw new NotImplementedException();
        }
    }
}