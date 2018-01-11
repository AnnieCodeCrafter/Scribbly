﻿using System;
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

        public Hoofdstuk GetHoofdstuk(int VerhaalID)
        {
            return context.GetHoofdstuk(VerhaalID);
        }
    }

}