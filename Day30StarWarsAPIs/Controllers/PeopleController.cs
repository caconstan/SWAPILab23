using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.IO;
using Day30StarWarsAPIs.Models;

namespace Day30StarWarsAPIs.Controllers
{
    public class PeopleController : Controller
    {
        private StarWarsDAL SW;

        public PeopleController(IConfiguration configuration)
        {
            SW = new StarWarsDAL(configuration);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string personURL)
        {
            string[] urlParts = personURL.Split("/");
            string personID = urlParts[5];

            Person s = SW.GetPerson(personID);
            ViewBag.personID = personID;
            return View(s);
        }
    }
}