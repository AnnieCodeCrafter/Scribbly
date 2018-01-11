using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScribblyDump.Interfaces;
using ScribblyDump.Models;
using System.Data.SqlClient;
using System.Data;
using ScribblyDump.ViewModel;

namespace ScribblyDump.Database
{
    public class HoofdstukSqlContext : DatabaseConnection, IHoofdstuk
    {
        public void AddHoofdstuk(Hoofdstuk H)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Hoofdstuk(Titel, Body, Nummer, VerhaalID) values (@Titel, @Body, @Nummer, @VerhaalID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Titel", H.Titel);
                    cmd.Parameters.AddWithValue("@Body", H.Body);
                    cmd.Parameters.AddWithValue("@Nummer", H.Nummer);
                    cmd.Parameters.AddWithValue("@VehraalID", H.VerhaalID);


                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}