using Microsoft.AspNetCore.Mvc;
using NetUI_EventsManager.Models;
using Newtonsoft.Json;
using System.Text;
using System.Globalization;

namespace NetUI_EventsManager.Controllers
{
    public class EventController : Controller
    {
        private readonly HttpClient _client;
        private readonly string _nameController = "Event";
        public EventController(IConfiguration iConfig)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            _client = new HttpClient();
            _client.BaseAddress = new Uri(iConfig.GetValue<string>("BaseAdress") ?? "");
        }


        /// <summary>
        /// Shows view of all events
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            List<EventViewModel> events = new List<EventViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + _nameController).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                events = JsonConvert.DeserializeObject<List<EventViewModel>>(result);
            }
            return View(events);
        }

        /// <summary>
        /// Shows form to create a new event
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Receives data from form and creates a new event
        /// </summary>
        /// <param name="eventViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(EventViewModel eventViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    eventViewModel.TimeZone = ""; // It is calculated in the API
                    var json = JsonConvert.SerializeObject(eventViewModel);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + _nameController, data).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successMessage"] = "Event created successfully.";
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception)
            {
                // Consider the logging mechanism here
                TempData["errorMessage"] = "Error creating event.";
                return View();
            }
            return View(eventViewModel);
        }

        /// <summary>
        /// Show details of an event
        /// </summary>
        public IActionResult Details(int id)
        {
            EventViewModel eventViewModel = new EventViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + _nameController + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                eventViewModel = JsonConvert.DeserializeObject<EventViewModel>(result);
            }
            return View(eventViewModel);
        }
    }
}
