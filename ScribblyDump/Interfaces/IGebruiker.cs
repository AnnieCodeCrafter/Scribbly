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
     
        


        //Gebruiker loginGebruiker
        Gebruiker loginGebruiker(Gebruiker obj);


       

       

        void SetGebrDescr(string username, string descr);

        Gebruiker getGebruiker(Gebruiker obj);


       
    }
}
