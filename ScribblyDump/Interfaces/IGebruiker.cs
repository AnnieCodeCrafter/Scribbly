using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ScribblyDump.Interfaces
{
    interface IGebruiker<T>
    {



        void addGebruiker(T obj);
        void deleteGebruiker(T obj);


        bool Inactief(bool yn);





       
    }
}
