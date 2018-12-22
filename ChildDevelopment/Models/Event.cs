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

    public List<int> GetDates()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT time FROM child_events WHERE event_id = @eventId;";
      cmd.Parameters.AddWithValue("@eventId", this._id);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<int> events = new List<int> { };

      while (rdr.Read())
      {
        int eventTime = rdr.GetInt32(0);
        events.Add(eventTime);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return events;
    }

    public static List<int> GetAverages()
    {
      List<int> averages = new List<int>();
      List <Event> events = Event.GetAll();
      foreach (var newEvent in events)
      {
        List<int> eventDates= newEvent.GetDates();
        int sum = 0;
        foreach (var eventDate in eventDates)
        {
          sum+=eventDate;
        }
        decimal division = sum/eventDates.Count;
        int average = Decimal.ToInt32(Math.Round(division));
        averages.Add(average);
      }
      return averages;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM events;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

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
