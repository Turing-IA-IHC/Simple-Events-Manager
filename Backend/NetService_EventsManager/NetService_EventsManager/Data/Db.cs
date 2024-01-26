using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using NetService_EventsManager.Models;


namespace NetService_EventsManager.Data
{
    /// <summary>
    /// Class for database connection.
    /// </summary>
    public static class DB
    {
        /// <summary>
        /// Create database file.
        /// </summary>
        public static void DbInit()
        {
            using (var connection = new SqliteConnection("Data Source=Data/events.db"))
            {
                connection.Open();

                // Read sql file with database creation
                string sql = System.IO.File.ReadAllText("Data/db_structure.sql");

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Create/Insert an event into database.
        /// </summary>
        /// <param name="evnt">Object Event to create.</param>
        /// <returns>Event ID.</returns>
        public static int CreateEvent(Event evnt)
        {
            int eventId = 0;
            using (var connection = new SqliteConnection("Data Source=Data/events.db"))
            {
                connection.Open();

                using (var command = new SqliteCommand())
                {
                    evnt.CalculateTimeZone();
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO events (name, description, start, end, latitude, longitude, timezone) VALUES (@name, @description, @start, @end, @latitude, @longitude, @timezone);";
                    command.Parameters.AddWithValue("@name", evnt.Name);
                    command.Parameters.AddWithValue("@description", evnt.Description);
                    command.Parameters.AddWithValue("@start", evnt.Start);
                    command.Parameters.AddWithValue("@end", evnt.End);
                    command.Parameters.AddWithValue("@latitude", evnt.Latitude);
                    command.Parameters.AddWithValue("@longitude", evnt.Longitude);
                    command.Parameters.AddWithValue("@timezone", evnt.TimeZone);

                    command.ExecuteNonQuery();

                    // Get Event ID
                    command.CommandText = "SELECT last_insert_rowid();";
                    eventId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return eventId;
        }

        /// <summary>
        /// Read/Select all events from database.
        /// </summary>
        public static List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();
            using (var connection = new SqliteConnection("Data Source=Data/events.db"))
            {
                connection.Open();

                using (var command = new SqliteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM events;";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Event e = new Event(
                                reader.GetInt32(0),     // Id
                                reader.GetString(1),    // Name
                                reader.GetString(2),    // Description
                                reader.GetDateTime(3),  // EventStartDate
                                reader.GetDateTime(4),  // EventEndDate
                                reader.GetDouble(5),    // Latitude
                                reader.GetDouble(6)     // Longitude
                                );

                            e.SetTimeZone(reader.GetString(7)); // TimeZone
                            events.Add(e);
                        }
                    }
                }
            }
            return events;
        }

        /// <summary>
        /// Return a single event from database.
        /// </summary>
        public static Event GetEvent(int id)
        {
            Event e = null;
            using (var connection = new SqliteConnection("Data Source=Data/events.db"))
            {
                connection.Open();

                using (var command = new SqliteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM events Where Id=@id;";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            e = new Event(
                                reader.GetInt32(0),     // Id
                                reader.GetString(1),    // Name
                                reader.GetString(2),    // Description
                                reader.GetDateTime(3),  // EventStartDate
                                reader.GetDateTime(4),  // EventEndDate
                                reader.GetDouble(5),    // Latitude
                                reader.GetDouble(6)     // Longitude
                                );

                            e.SetTimeZone(reader.GetString(7)); // TimeZone
                        }
                    }
                }
            }
            return e;
        }
    }
}
