using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsecTimeLine.Models;
using InsecTimeLine.Services;
using Microsoft.AspNetCore.Http;

namespace InsecTimeLine.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventFormViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _eventService.AddNewEvent(model);
            return Content("Done");
        }
    }
}