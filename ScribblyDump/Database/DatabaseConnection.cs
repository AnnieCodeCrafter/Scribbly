using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScribblyDump.Database
{
    public abstract class DatabaseConnection
    {
        private string connectionString = @"Data Source=DESKTOP-FDBIS08\SQLSERVER;Initial Catalog=LocalScrib;Integrated Security=True";


        public void openCon(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void closeCon(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }



    
}
