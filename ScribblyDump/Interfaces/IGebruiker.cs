using ScribblyDump.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ScribblyDump.Interfaces
{
    public interface IGebruiker
    {



        void addGebruiker(string Username, string Password);
        // changed from Gebruiker obj to this, change if necessary
        void deleteGebruiker(Gebruiker obj);


        bool Inactief(bool yn);





       
    }
}
