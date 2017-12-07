using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScribblyDump.Models;

namespace ScribblyDump.Interfaces
{
    public interface IVerhaal
    {
       void AddVerhaal(Verhaal V);

       void GetVerhaal(int id);
    }
}
