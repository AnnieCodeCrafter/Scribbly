using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScribblyDump.Models;
using ScribblyDump.ViewModel;

namespace ScribblyDump.Interfaces
{
  public  interface IHoofdstuk
    {
        void AddHoofdstuk(Hoofdstuk H);

        Hoofdstuk GetHoofdstuk(int VerhaalID);
    
    }
}
