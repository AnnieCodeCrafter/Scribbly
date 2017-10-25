using ScribblyDump.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScribblyDump.Models;
using ScribblyDump.Database;
using System.Data.SqlClient;
using System.Data;

namespace ScribblyDump.Database
{
    public class GebruikerSqlContext : DatabaseConnection, IGebruiker
    {
        public void addGebruiker(Gebruiker obj)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Gebruiker VALUES (@username, @password)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@username", obj.Username);
                    cmd.Parameters.AddWithValue("@password", obj.Password);

                    cmd.ExecuteNonQuery();
                }
            }
            
        }

        public void deleteGebruiker(Gebruiker obj)
        {
            throw new NotImplementedException();
        }

        public bool Inactief(bool yn)
        {
            throw new NotImplementedException();
        }
    }
}