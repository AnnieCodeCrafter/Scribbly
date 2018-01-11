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

        public List<Verhaal> GetListVerhalen(int id)
        {
            return context.GetListVerhalen(id);
        }

        public List<VerhaalViewModel> ToListViewModel(int usID)
        {
            return context.ToListViewModel(usID);
        }

        public VerhaalViewModel ToViewModel(Verhaal V)
        {
            return context.ToViewModel(V);
        }

        public Verhaal GetVerhaal(int id)
        {
            return context.GetVerhaal(id);
        }

        public void DeleteVerhaal(Verhaal V)
        {
            this.context.DeleteVerhaal(V);
        }

        public List<VerhaalViewModel> ShortlistProcedure(int usid)
        {
            return context.ShortlistProcedure(usid);
        }

    }
}