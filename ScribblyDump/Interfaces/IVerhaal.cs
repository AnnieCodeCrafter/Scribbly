using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScribblyDump.Models;
using ScribblyDump.ViewModel;

namespace ScribblyDump.Interfaces
{
    public interface IVerhaal
    {
       void AddVerhaal(Verhaal V);

       List<Verhaal> GetListVerhalen(int id);

        List<VerhaalViewModel> ToListViewModel(int usID);

        Verhaal GetVerhaal(int id);

        VerhaalViewModel ToViewModel(Verhaal V);

        void DeleteVerhaal(Verhaal V);

        List<VerhaalViewModel> ShortlistProcedure(int usid);



    }
}
