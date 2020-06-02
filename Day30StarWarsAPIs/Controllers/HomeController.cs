using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Day30StarWarsAPIs.Models;
using Microsoft.Extensions.Configuration;

namespace Day30StarWarsAPIs.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private StarWarsDAL SW;
        public HomeController(IConfiguration configuration)
        {
            SW = new StarWarsDAL(configuration);
        }

        public IActionResult Index()
        {
            List<Person> lp = SW.GetPeople();
            return View(lp);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
