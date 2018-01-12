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
                    cmd.Parameters.AddWithValue("@VerhaalID", H.VerhaalID);


                    cmd.ExecuteNonQuery();

                }
            }
        }

        public List<Hoofdstuk> GetHoofdstuk(int VerhaalID)
        {
            Hoofdstuk H = new Hoofdstuk();
            List<Hoofdstuk> HL = new List<Hoofdstuk>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "select ID, Titel, Body, Nummer from Hoofdstuk where VerhaalID = @VerhaalID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@VerhaalID", VerhaalID);
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Titel = (string)reader["Titel"];
                            string Body = (string)reader["Body"];
                            int Nummer = (int)reader["Nummer"];
                            int HfdstkID = (int)reader["ID"];
                            H = new Hoofdstuk(Titel, Body, Nummer, VerhaalID, HfdstkID);
                            HL.Add(H);
                        }
                    }
                }

                return HL;

            }
        }

        public Hoofdstuk getSingleHoofdstuk(int hfdstkID, int VerhaalID)
        {
            Hoofdstuk H = new Hoofdstuk();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "select ID, Titel, Body, Nummer from Hoofdstuk where VerhaalID = @VerhaalID and ID = @HfdstkID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@VerhaalID", VerhaalID);
                    cmd.Parameters.AddWithValue("@hfdstkID", hfdstkID);
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Titel = (string)reader["Titel"];
                            string Body = (string)reader["Body"];
                            int Nummer = (int)reader["Nummer"];
                            int HfdstkID = (int)reader["ID"];
                        

                            H = new Hoofdstuk(Titel, Body, Nummer, VerhaalID, HfdstkID);
                           
                        }
                    }
                }
            }
            return H;
        }

        public List<HoofdstukViewModel> ToListViewModel(List<Hoofdstuk> Hoofdstukken)
        {
            List<HoofdstukViewModel> HL = new List<HoofdstukViewModel>();
            HoofdstukViewModel H;

            foreach (Hoofdstuk F in Hoofdstukken)
            {
                H = new HoofdstukViewModel(F.Titel, F.Body, F.Nummer, F.VerhaalID, F.HoofdstukID);
                HL.Add(H);
            }

            return HL;
        }

        public HoofdstukViewModel ToViewModel(Hoofdstuk H)
        {
            HoofdstukViewModel F = new HoofdstukViewModel(H.Titel, H.Body, H.Nummer, H.VerhaalID, H.HoofdstukID);
            return F;
        }
    }
}