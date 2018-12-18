using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ChildDevelopment;

namespace ChildDevelopment.Models
{
    public class Patron
    {
        private string _name;
        private string _password;

        public Patron(string name, string password)
        {
            _name = name;
            _password = password;
           
        }

        public string GetName()
        {
            return _name;
        }

        public string GetPassword()
        {
            return _password;
        }


        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO login (username, password) VALUES (@name, @password);";
            cmd.Parameters.AddWithValue("@name", this._name);
            cmd.Parameters.AddWithValue("@password", this._password);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

         public static Patron FindByName(string inputName, string inputPassword)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM login WHERE username = @name AND password = @password;";

            cmd.Parameters.AddWithValue("@name", inputName);
            cmd.Parameters.AddWithValue("@password", inputPassword);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            string name = "none";
            string password = "none";
            while (rdr.Read())
            {
               name = inputName;
                password = rdr.GetString(1);
            }
            Patron newPatron = new Patron(name, password);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newPatron;
        }

       public override bool Equals(System.Object otherPatron)
        {
            if (!(otherPatron is Patron))
            {
                return false;
            }
            else
            {
                Patron newPatron = (Patron)otherPatron;
                bool nameEquality = (this.GetName() == newPatron.GetName());
                bool passwordEquality = (this.GetPassword() == newPatron.GetPassword());

                return (nameEquality && passwordEquality);
            }
        }
             public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }
    }
}
