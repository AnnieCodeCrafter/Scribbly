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

       List<Verhaal> GetVerhaal(int id);

        List<VerhaalViewModel> ToViewModel(int usID);
    }
}
