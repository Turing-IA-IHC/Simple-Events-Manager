using Microsoft.AspNetCore.Mvc;
using NetService_EventsManager.Models;
using NetService_EventsManager.Data;

namespace NetService_EventsManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        /// <summary>
        /// Returns all events from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEvents()
        {
            List<Event> events = DB.GetEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            Event evnt = DB.GetEvent(id);
            return Ok(evnt);
        }

        /// <summary>
        /// Creata an event in database.
        /// </summary>
        [HttpPost]
        public IActionResult CreateEvent(Event evnt)
        {
            int eventId = DB.CreateEvent(evnt);
            return Ok(eventId);
        }
    }
}
