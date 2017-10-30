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
         public void addGebruiker(string Username, string Password, string Email)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Gebruiker(Gebruikersnaam, Wachtwoord, Email) VALUES (@Gebruikersnaam, @Wachtwoord, @Email)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Gebruikersnaam", Username);
                    cmd.Parameters.AddWithValue("@Wachtwoord", Password);
                    cmd.Parameters.AddWithValue("@Email", Email);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public bool loginGebruiker(string Username, string Password)
        { 
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT ID, Gebruikersnaam, Wachtwoord FROM Gebruiker WHERE Gebruikersnaam = @username AND Wachtwoord = @password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@username", Username);
                    cmd.Parameters.AddWithValue("@password", Password);

                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int ID = ((int)reader["ID"]);
                        }
                    }


                    conn.Close();

                    if (count == 1)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }
            }
        }

        public void deleteGebruiker(Gebruiker obj)
        {
            
        }

        public bool Inactief(bool yn)
        {
            throw new NotImplementedException();
        }

       
    }
}