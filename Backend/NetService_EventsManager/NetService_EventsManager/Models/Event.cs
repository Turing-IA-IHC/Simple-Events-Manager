using GeoTimeZone;

namespace NetService_EventsManager.Models
{
    /// <summary>
    /// Class for Event object.
    /// </summary>
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string TimeZone { get; set; }

        /// <summary>
        /// Constructor for Event object.
        /// </summary>
        /// <param name="id">Id of Event.</param>
        /// <param name="name">Event name.</param>
        /// <param name="description">Event description.</param>
        /// <param name="start">Date and time of event start.</param>
        /// <param name="end">Date and time of event end.</param>
        /// <param name="latitude">Event latitude location.</param>
        /// <param name="longitude">Event longitude location.</param>
        public Event(int id, string name, string description, DateTime start, DateTime end, double latitude, double longitude)
        {
            Id = id;
            Name = name.Length > 32 ? name.Substring(0, 32) : name; // limit to 32 characters to avoid problems with the database
            Description = description;
            Start = start;
            End = end;
            Latitude = latitude;
            Longitude = longitude;
            TimeZone = "Unknown";
        }

        /// <summary>
        /// Set the TimeZone property of the Event object.
        /// </summary>
        /// <param name="timeZone"></param>
        public void SetTimeZone(string timeZone)
        {
            TimeZone = timeZone;
        }

        /// <summary>
        /// Calculate the TimeZone property of the Event object from Latitude and Longitude.
        /// </summary>
        public void CalculateTimeZone()
        {
            TimeZone = TimeZoneLookup.GetTimeZone(Latitude, Longitude).Result;
        }


    }
}
