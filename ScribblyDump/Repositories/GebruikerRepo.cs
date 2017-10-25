using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScribblyDump.Controllers;
using ScribblyDump.Database;
using ScribblyDump.Interfaces;

namespace ScribblyDump.Repositories
{
    public class GebruikerRepo
    {
        IGebruiker context;

        GebruikerRepo(IGebruiker context)
        {
            this.context = context;
        }
        

    }
}