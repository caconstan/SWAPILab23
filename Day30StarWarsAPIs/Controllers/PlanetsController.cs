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
    public class PlanetsController : Controller
    {
        private StarWarsDAL SW;

        public PlanetsController(IConfiguration configuration)
        {
            //IConfiguration configuration
            //_configuration = configuration.GetSection("APIKeys")["OmdbAPI"];
            SW = new StarWarsDAL(configuration);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string planetID)
        {
            Planet p = SW.GetPlanet(planetID);
            ViewBag.planetID = planetID;
            return View(p);
        }
    }
}