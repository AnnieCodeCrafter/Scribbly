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

        public List<Verhaal> GetListVerhalen(int id)
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

                    if (count > 0)
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


        public Verhaal GetVerhaal(int id)
        {
            Verhaal V = new Verhaal();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * from Verhaal WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);

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

                        }

                    }
                }
                conn.Close();
                return V;
            }

        }
        public List<VerhaalViewModel> ToListViewModel(List<Verhaal> LV)
        {
            List<VerhaalViewModel> F = new List<VerhaalViewModel>();
            VerhaalViewModel V;
            foreach (Verhaal H in LV)
            {
                int usid = H.AuteurID;
                string Titel = H.Titel;
                string Desc = H.Beschrijving;
                genre Genre = (genre)((int)H.VerhaalGenre);
                int ID = H.ID;
                V = new VerhaalViewModel(ID, Titel, Desc, Genre, usid);
                F.Add(V);
            }

            return F;

        }

        public VerhaalViewModel ToViewModel(Verhaal H)
        {
            VerhaalViewModel V;
            int usID = H.AuteurID;
            string Titel = H.Titel;
            string Desc = H.Beschrijving;
            genre Genre = (genre)((int)H.VerhaalGenre);
            int ID = H.ID;
            V = new VerhaalViewModel(ID, Titel, Desc, Genre, usID);
            return V;

        }

        public void DeleteVerhaal(Verhaal H)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Verhaal WHERE ID = @id AND AuteurID = @AuteurID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@id", H.ID);
                    cmd.Parameters.AddWithValue("@AuteurID", H.AuteurID);

                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }

        }

        public List<VerhaalViewModel> ShortlistProcedure(int usid)
        {
            List<VerhaalViewModel> F = new List<VerhaalViewModel>();
            VerhaalViewModel V;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                "HaalVerhalenVanAuteur", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(
                    new SqlParameter("@ID", usid));

                // execute the command
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Titel = (string)reader["Titel"];
                        V = new VerhaalViewModel(Titel);
                        F.Add(V);
                    }

                }

                conn.Close();
            }

            return F;

        }

        public List<Verhaal> GetAlleVerhalen()
        {

            List<Verhaal> F = new List<Verhaal>();
            Verhaal V = new Verhaal();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * from Verhaal";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);

                    int count = ds.Tables[0].Rows.Count;

                    //conn.Close();

                    if (count > 0)
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
    }

}