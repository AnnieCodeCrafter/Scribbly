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

        void addGebruiker(Gebruiker obj);
     
        void deleteGebruiker(Gebruiker obj);


        //Gebruiker loginGebruiker
        Gebruiker loginGebruiker(Gebruiker obj);


        bool Inactief(bool yn);

        void GetGebrDescr(Gebruiker obj);

        void SetGebrDescr(string username, string descr);

        Gebruiker getGebruiker(Gebruiker obj);


       
    }
}
