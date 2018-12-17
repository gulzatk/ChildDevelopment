using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ChildDevelopment;

namespace ChildDevelopment.Models
{
    public class Child
    {
        private string _name;
        private bool _gender;
        private int _height;
        private int _weight;
        private bool _breastfeeding ;
        private DateTime _birthdate;
        private int _id;

        public Child(string name, bool gender, int weight, int height, DateTime birthdate, bool breastfeeding, int id = 0)
        {
            _name = name;
            _gender = gender;
            _weight = weight;
            _height = height;
            _birthdate = birthdate;
            _breastfeeding = breastfeeding;
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public bool GetGender()
        {
            return _gender;
        }

        public int GetHeight()
        {
            return _height;
        }

        public int GetWeight()
        {
            return _weight;
        }
        public bool GetBreastfeeding()
        {
            return _breastfeeding;
        }

        public DateTime GetBirthdate()
        {
            return _birthdate;
        }

        public int GetId()
        {
            return _id;
        }

        public static List<Child> GetAll()
        {
            List<Child> allChilds = new List<Child> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM children;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                bool gender = rdr.GetBoolean(2);
                int weight = rdr.GetInt32(3);
                int height = rdr.GetInt32(4);
                DateTime birthdate = rdr.GetDateTime(5);
                bool breastfeeding = rdr.GetBoolean(6);

               Child newChild = new Child(name, gender, weight, height, birthdate, breastfeeding, id);
                allChilds.Add(newChild);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allChilds;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO children (name, gender, weight, height,  birthdate, breastfeeding) VALUES (@name, @gender, @weight, @height, @birthdate, @breastfeeding);";
            cmd.Parameters.AddWithValue("@name", this._name);
            cmd.Parameters.AddWithValue("@gender", this._gender);
            cmd.Parameters.AddWithValue("@weight", this._weight);
            cmd.Parameters.AddWithValue("@height", this._height);
            cmd.Parameters.AddWithValue("@birthdate", this._birthdate);
            cmd.Parameters.AddWithValue("@breastfeeding", this._breastfeeding);
            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null) 
            {
                conn.Dispose();
            }
        }

         public static Child Find(int Id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM children WHERE id = @childId;";

            MySqlParameter childId = new MySqlParameter();
            childId.ParameterName = "@childId";
            childId.Value = Id;
            cmd.Parameters.Add(childId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id = 0;
            string name = "";
            bool gender = false;
            int weight = 0;
            int height = 0;
            DateTime birthdate = new DateTime();
            bool breastfeeding = false;
            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
                name = rdr.GetString(1);
                gender = rdr.GetBoolean(2);
                weight = rdr.GetInt32(3);
                height = rdr.GetInt32(4);
                birthdate = rdr.GetDateTime(5);
                breastfeeding = rdr.GetBoolean(6);
            }
            Child newChild = new Child(name, gender, weight, height, birthdate, breastfeeding, id);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newChild;
        }

        public void AddChildEvents(int eventId, DateTime time)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO child_events (child_id,event_id,time) VALUES (@childId,@eventId,@time);";

            cmd.Parameters.AddWithValue("@childId", this._id);
            cmd.Parameters.AddWithValue("@eventId", eventId);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

          public List<Event> GetEvents()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT events.* FROM children
                JOIN child_events ON (children.id = child_events.child_id)
                JOIN events ON (child_events.event_id = events.id)
                WHERE children.id = @childId;";
                cmd.Parameters.AddWithValue("@childId", this._id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Event> events = new List<Event> { };
            while (rdr.Read())
            {
                int eventId = rdr.GetInt32(0);
                string eventName = rdr.GetString(1);

                Event newEvent = new Event(eventName, eventId);
                events.Add(newEvent);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return events;
        }

        public void Edit(string name, bool gender, int weight, int height, DateTime birthdate, bool breastfeeding)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE children SET (name, gender, weight, height, birthdate, breastfeeding) = (@name, @gender, @weight, @height, @birthdate, @breastfeeding) WHERE id = @searchId;";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@weight", weight);
            cmd.Parameters.AddWithValue("@height", height);
            cmd.Parameters.AddWithValue("@birthdate", birthdate);
            cmd.Parameters.AddWithValue("@breastfeeding", breastfeeding);
            cmd.Parameters.AddWithValue("@searchId", this._id);
            cmd.ExecuteNonQuery();
            _name = name;
            _gender = gender;
            _weight = weight;
            _height = height;
            _birthdate = birthdate;
            _breastfeeding = breastfeeding;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("DELETE FROM children WHERE id = @childId;");
            cmd.Parameters.AddWithValue("@childId", this._id);
            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM children;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherChild)
        {
            if (!(otherChild is Child))
            {
                return false;
            }
            else
            {
                Child newChild = (Child)otherChild;
                bool idEquality = (this.GetId() == newChild.GetId());
                bool nameEquality = (this.GetName() == newChild.GetName());
                bool genderEquality = (this.GetGender() == newChild.GetGender());
                bool weightEquality = (this.GetWeight() == newChild.GetWeight());
                bool heightEquality = (this.GetHeight() == newChild.GetHeight());
                bool birthdateEquality = (this.GetBirthdate() == newChild.GetBirthdate());
                bool breastfeedingEquality = (this.GetBreastfeeding() == newChild.GetBreastfeeding());
                return (idEquality && nameEquality && genderEquality && weightEquality && heightEquality && birthdateEquality && breastfeedingEquality);
            }
        }
        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }
    }
}