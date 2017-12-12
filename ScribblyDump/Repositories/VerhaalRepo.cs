using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScribblyDump.Interfaces;
using ScribblyDump.Models;
using ScribblyDump.ViewModel;

namespace ScribblyDump.Repositories
{
    public class VerhaalRepo
    {
        IVerhaal context;

        public VerhaalRepo(IVerhaal context)
        {
            this.context = context;
        }

        public void AddVerhaal(Verhaal V)
        {
            this.context.AddVerhaal(V);
        }

        public List<Verhaal> GetVerhaal(int id)
        {
            return context.GetVerhaal(id);
        }

        public List<VerhaalViewModel> ToViewModel(int usID)
        {
            return context.ToViewModel(usID);
        }


    }
}