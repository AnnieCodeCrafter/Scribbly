using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScribblyDump.Interfaces;
using ScribblyDump.Models;
using System.Data.SqlClient;
using System.Data;

namespace ScribblyDump.Database
{
    public class VerhaalSqlContext : DatabaseConnection, IVerhaal
    {
        public void AddVerhaal(Verhaal V)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Verhaal(Titel, Beschrijving, Genre, AuteurID) VALUES (@Titel, @Beschrijving, @Genre, @AuteurID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Titel", V.Titel);
                    cmd.Parameters.AddWithValue("@Beschrijving", V.Beschrijving);
                    cmd.Parameters.AddWithValue("@Genre", V.Genre);
                    cmd.Parameters.AddWithValue("@AuteurID", V.AuteurID);


                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
        }

        public void GetVerhaal(Verhaal V)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * from Verhaal WHERE AuteurID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", V.AuteurID);
                    cmd.ExecuteNonQuery();
                }

            }

        }
    }

}