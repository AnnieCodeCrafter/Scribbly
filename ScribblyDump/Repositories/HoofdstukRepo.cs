using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScribblyDump.Interfaces;
using ScribblyDump.Models;
using ScribblyDump.ViewModel;

namespace ScribblyDump.Repositories
{
   
    public class HoofdstukRepo
    {
        IHoofdstuk context;

        public HoofdstukRepo(IHoofdstuk context)
        {
            this.context = context;
        }

        public void AddHoofdstuk(Hoofdstuk H)
        {
            this.context.AddHoofdstuk(H);
        }

        public List<Hoofdstuk> GetHoofdstuk(int VerhaalID)
        {
            return context.GetHoofdstuk(VerhaalID);
        }

        public List<HoofdstukViewModel> ToListViewModel(List<Hoofdstuk> H)
        {
            return context.ToListViewModel(H);
        }

        public Hoofdstuk getSingleHoofdstuk(int hfdstkID, int VerhaalID)
        {
            return context.getSingleHoofdstuk(hfdstkID, VerhaalID);
        }

        public HoofdstukViewModel ToViewModel(Hoofdstuk H)
        {
            return context.ToViewModel(H);
        }
    }

}