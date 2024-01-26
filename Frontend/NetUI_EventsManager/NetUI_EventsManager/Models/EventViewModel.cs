using System.ComponentModel;

namespace NetUI_EventsManager.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Start Date")]
        public DateTime Start { get; set; }
        [DisplayName("End Date")]
        public DateTime End { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? TimeZone { get; set; }
    }
}
