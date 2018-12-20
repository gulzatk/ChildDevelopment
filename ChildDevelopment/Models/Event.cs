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

<<<<<<< HEAD
        //     public List<int> GetDates()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"SELECT time FROM child_events WHERE event_id = @eventId;";
        //     cmd.Parameters.AddWithValue("@eventId", this._id);
        //     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        //     List<int> events = new List<int> { };
        //     while (rdr.Read())
        //     {

        //         DateTime newEvent = rdr.GetDateTime(0);
        //         int weeks = (int)Math.Round(newEvent.Ticks/6048000000000);
        //         events.Add(weeks);
=======
            public List<int> GetDates()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT time FROM child_events WHERE event_id = @eventId;";
            cmd.Parameters.AddWithValue("@eventId", this._id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<int> events = new List<int> { };
            DateTime aPastDate = new DateTime(2006, 1, 1);
            while (rdr.Read())
            {

                DateTime newEvent = rdr.GetDateTime(0);
                int difference = (int)Math.Round(((newEvent - aPastDate).TotalDays)/7);
                events.Add(difference);
>>>>>>> origin/kaveh

        //     }
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        //     return events;
        // }
        // public List<int> GetBirthdates()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"SELECT child_id FROM child_events WHERE event_id = @eventId;";
        //     cmd.Parameters.AddWithValue("@eventId", this._id);
        //     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        //     List<int> childIds = new List<int> { };
        //     while (rdr.Read())
        //     {

        //         int newChildId = rdr.GetInt32(0);
        //         childIds.Add(newChildId);

<<<<<<< HEAD
        //     }
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        //     List<int> birthdates = new List<int>();
        //     foreach (var childId in childIds)
        //     {
        //       Child child= Child.Find(childId);
        //       int weeks = (int)Math.Round(child.GetBirthdate().Ticks/6048000000000);
        //       birthdates.Add(weeks);
        //     }
        //     return birthdates;
        // }
        // public static List<int> GetAverages()
        // {
        //   List<int> averages = new List<int>();
        //   List <Event> events = Event.GetAll();
        //   foreach (var newEvent in events)
        //   {
        //     List<int> eventDates= newEvent.GetDates();
        //     List<int> eventBirthdates = newEvent.GetBirthdates();
        //     int sum = 0;

        //     for (int i =0;i<eventDates.Count;i++)
        //     {
        //       sum+=eventDates[i]-eventBirthdates[i];
        //     }
        //     averages.Add((int)Math.Round(sum/eventDates.Count));
        //   }
        //   return averages;
        // }
=======
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            List<int> birthdates = new List<int>();
            foreach (var childId in childIds)
            {
              Child child= Child.Find(childId);
              DateTime aPastDate = new DateTime(2006, 1, 1);
              int difference = (int)Math.Round(((child.GetBirthdate() - aPastDate).TotalDays)/7);
              birthdates.Add(difference);

            }
            return birthdates;
        }
        public static List<int> GetAverages()
        {
          List<int> averages = new List<int>();
          List <Event> events = Event.GetAll();
          foreach (var newEvent in events)
          {
            List<int> eventDates= newEvent.GetDates();
            List<int> eventBirthdates = newEvent.GetBirthdates();
            int sum = 0;
            for (int i =0;i<eventDates.Count;i++)
            {
              sum+=eventDates[i];
              sum-=eventBirthdates[i];
            Console.WriteLine(eventBirthdates[i]);
            }
              decimal division = sum/eventDates.Count;
              int average = Decimal.ToInt32(Math.Round(division));
              averages.Add(average);

          }
          return averages;
        }
>>>>>>> origin/kaveh

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
