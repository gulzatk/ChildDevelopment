using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ChildDevelopment;

namespace ChildDevelopment.Models
{
    public class Event
    {
        private int _id;
        private string _name;

        public Event(string name, int id = 0)
        {
            _name = name;
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public static List<Event> GetAll()
        {
            List<Event> allEvents = new List<Event> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM events;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Event newEvent = new Event(name, id);
                allEvents.Add(newEvent);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allEvents;
        }

        // public void Save()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"INSERT INTO events (name) VALUES (@name);";

        //     cmd.Parameters.AddWithValue("@name", this._name);
        //     cmd.ExecuteNonQuery();
        //     _id = (int)cmd.LastInsertedId;
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }

         public static Event Find(int Id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM events WHERE id = @eventId;";
            cmd.Parameters.AddWithValue("@eventId", Id);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id = 0;
            string eventName = "";
            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
                eventName = rdr.GetString(1);
            }
            Event foundEvent = new Event(eventName, id);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundEvent;
        }

        //  public static void ClearAll()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"DELETE FROM events;";
        //     cmd.ExecuteNonQuery();
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }

       public override bool Equals(System.Object otherEvent)
        {
            if (!(otherEvent is Event))
            {
                return false;
            }
            else
            {
                Event newEvent = (Event)otherEvent;
                bool idEquality = (this.GetId() == newEvent.GetId());
                bool nameEquality = (this.GetName() == newEvent.GetName());
                return (idEquality && nameEquality);
            }
        }
             public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }
    }
}
