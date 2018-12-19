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
        private int _childId;

        public Patron(string name, string password, int childId)
        {
            _name = name;
            _password = password;
            _childId = childId;

        }

        public string GetName()
        {
            return _name;
        }

        public string GetPassword()
        {
            return _password;
        }

        public int GetChildId()
        {
            return _childId;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO login (username, password, child_id) VALUES (@name, @password, @childId);";
            cmd.Parameters.AddWithValue("@name", this._name);
            cmd.Parameters.AddWithValue("@password", this._password);
            cmd.Parameters.AddWithValue("@childId", this._childId);
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static bool IsUnique(string name)
        {
            bool unique = false;
            List<Patron> newList = GetAll();
            foreach(Patron p in newList)
            {
                if (p.GetName() == name)
                {
                    unique = true;
                }
            }
            return unique;
        }

         public static Patron FindByName(string inputName, string inputPassword, int inputChildId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM login WHERE username = @name AND password = @password;";

            cmd.Parameters.AddWithValue("@name", inputName);
            cmd.Parameters.AddWithValue("@password", inputPassword);
             cmd.Parameters.AddWithValue("@childId", inputChildId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            string name = "none";
            string password = "none";
            int childId = 0;
            while (rdr.Read())
            {
               name = inputName;
                password = rdr.GetString(1);
                childId = rdr.GetInt32(2);
            }
            Patron newPatron = new Patron(name, password, childId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newPatron;
        }

           public static List<Patron> GetAll()
        {
            List<Patron> allPatrons = new List<Patron> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM login;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string name = rdr.GetString(0);
                string password = rdr.GetString(1);
                int childId = rdr.GetInt32(2);

               Patron newPatron = new Patron(name, password, childId);
                allPatrons.Add(newPatron);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allPatrons;
        }

        public static List<Patron> GetAllByChildId(int id)
        {
            List<Patron> patron = new List<Patron> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM login WHERE childId = '" + id + "';";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
            string patronName = rdr.GetString(0);
            string patronPassword = rdr.GetString(1);
            int childId = rdr.GetInt32(2);

            Patron newPatron = new Patron(patronName, patronPassword, childId);
            patron.Add(newPatron);
            }
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return patron;
        }

           public void Edit(string inputName, string inputPassword)
            {
                MySqlConnection conn = DB.Connection();
                conn.Open();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"UPDATE login SET username = @inputName AND password = @inputPassword WHERE name = @searchName;";
                cmd.Parameters.AddWithValue("@name", inputName);
                cmd.Parameters.AddWithValue("@inputPassword", inputPassword);
                cmd.Parameters.AddWithValue("@searchName", this._name);
                cmd.ExecuteNonQuery();
                _name = inputName;
                conn.Close();
                if (conn != null)
                {
                conn.Dispose();
                }
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
                bool childIdEquality = (this.GetChildId() == newPatron.GetChildId());


                return (nameEquality && passwordEquality && childIdEquality);
            }
        }
             public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }
    }
}
