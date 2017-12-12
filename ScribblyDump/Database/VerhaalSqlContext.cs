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

        public List<Verhaal> GetVerhaal(int id)
        {
            List<Verhaal> F = new List<Verhaal>();
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

                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);

                    int count = ds.Tables[0].Rows.Count;

                    //conn.Close();

                    if (count > 0 )
                    {
                       using (SqlDataReader reader = cmd.ExecuteReader())
                      {
                            while (reader.Read())
                            {
                                // get everything from the things and make a new obj
                                    int ID = (int)reader["ID"];
                                    string Titel = (string)reader["Titel"];
                                    string Desc = (string)reader["Beschrijving"];
                                    string genre = ((string)reader["Genre"]);
                                    int AutID = (int)reader["AuteurID"];

                                    // Enum.TryParse(genre, out VerhaalGenres genres);
                                    VerhaalGenres MyGenres = (VerhaalGenres)Enum.Parse(typeof(VerhaalGenres), genre, true);
                                    V = new Verhaal(ID, Titel, Desc, MyGenres, AutID);
                                    F.Add(V);
                            }
                       }
                    }               
                }
                return F;
            }
        }
        public List<VerhaalViewModel> ToViewModel(int usID)
        {
            List<VerhaalViewModel> F = new List<VerhaalViewModel>();
            VerhaalViewModel V;
            foreach (Verhaal H in GetVerhaal(usID))
            {
                string Titel = H.Titel;
                string Desc = H.Beschrijving;
                genre Genre = (genre)((int)H.VerhaalGenre);
                int ID = H.ID;
                V = new VerhaalViewModel(ID, Titel, Desc, Genre, usID);
                F.Add(V);
            }
         
            return F;

        }
    }

}