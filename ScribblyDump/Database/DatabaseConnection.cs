using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScribblyDump.Database
{
    public abstract class DatabaseConnection
    {
        private string connectionString = "Data Source=mssql.fhict.local;Initial Catalog = dbi364679;User ID = dbi364679;Password = Thorax1998";
        public string ConnectionString
        {
            get { return connectionString; }
        }

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
