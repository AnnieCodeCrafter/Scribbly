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
                    cmd.Parameters.AddWithValue("@Genre", V.VerhaalGenre);
                    cmd.Parameters.AddWithValue("@AuteurID", V.AuteurID);


                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
        }

        public Verhaal GetVerhaal(int id)
        {
            Verhaal V = new Verhaal();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * from Verhaal WHERE AuteurID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // get everything from the things and make a new obj
                            string Titel = (string)reader["Titel"];
                            string Desc = (string)reader["Beschrijving"];
                            string genre = ((string)reader["Genre"]);
                            int AutID = (int)reader["AuteurID"];
                           // Enum.TryParse(genre, out VerhaalGenres genres);
                            VerhaalGenres MyGenres = (VerhaalGenres)Enum.Parse(typeof(VerhaalGenres), genre, true);
                            V = new Verhaal (Titel, Desc, MyGenres, AutID);

                        }
                    }
                }
                return V;

            }

        }
    }

}