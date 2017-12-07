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
                string query = "INSERT INTO Gebruiker(Gebruikersnaam, Wachtwoord, Email, profilepic, description) VALUES (@Gebruikersnaam, @Wachtwoord, @Email, @Profilepic, @Descr)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Gebruikersnaam", obj.Username);
                    cmd.Parameters.AddWithValue("@Wachtwoord", obj.Password);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Descr", "Description Here");
                    cmd.Parameters.AddWithValue("@Profilepic", "none");

                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }

        }

        public Gebruiker loginGebruiker(Gebruiker obj)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Gebruiker WHERE Gebruikersnaam = @username AND Wachtwoord = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", obj.Username);
                        cmd.Parameters.AddWithValue("@password", obj.Password);

                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapt.Fill(ds);

                        int count = ds.Tables[0].Rows.Count;

                        //conn.Close();

                        if (count == 1)
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // get everything from the things and make a new obj
                                    string desc = (string)reader["description"];
                                    string email = (string)reader["Email"];
                                    int ID = ((int)reader["ID"]);
                                    string profilePic = (string)reader["profilePic"];

                                    obj = new Gebruiker(obj.Username, obj.Password, email, desc, profilePic);

                                }
                            }

                        }

                        else
                        {
                            obj = null;
                        }


                    }
                }

                finally
                {
                    conn.Close();
                }
                return obj;
            }
        }

        public Gebruiker getGebruiker(Gebruiker obj)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Gebruiker WHERE Gebruikersnaam = @username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", obj.Username);
                        cmd.ExecuteNonQuery();

                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapt.Fill(ds);


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // get everything from the things and make a new obj
                                string desc = (string)reader["description"];
                                string email = (string)reader["Email"];
                                int ID = ((int)reader["ID"]);
                                string profilePic = (string)reader["profilePic"];
                                obj = new Gebruiker(obj.Username, obj.Password, email, desc, profilePic);
                            }
                        }
                    }
                }
                catch
                {
                    obj = null;
                }
                finally
                {
                    conn.Close();
                }
                return obj;
            }


        }



        public void SetGebrDescr(string username, string descr)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Gebruiker SET description = @descr WHERE Gebruikersnaam = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@descr", descr);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.ExecuteNonQuery();

                    }

                }

                catch
                {

                }

                finally
                {
                    conn.Close();
                }

            }
        }

        public int GetGebruikerID(string username)
        {
            int ID = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT ID FROM Gebruiker WHERE Gebruikersnaam = @username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ID = ((int)reader["ID"]);
                           
                        }                       
                    }

                  
                }
                return ID;
            }
           
        }
    }
}