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

        List<Hoofdstuk> GetHoofdstuk(int VerhaalID);

        List<HoofdstukViewModel> ToListViewModel(List<Hoofdstuk> H);

        Hoofdstuk getSingleHoofdstuk(int hfdstkID, int VerhaalID);
        HoofdstukViewModel ToViewModel(Hoofdstuk H);

    }
}
