using System.Diagnostics;
using BlockBuster.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using BlockBuster;
using BlockBuster.Models;


namespace BlockBuster.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string[] _myColors;
        private readonly string[] _myCities;
        private readonly string[] _myHobbies;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _myColors = ["red", "green", "blue"];
            _myCities = ["New York","Cartago", "Los Angeles", "Chicago", "San Jose"];
            _myHobbies = ["Hiking", "Marvel Rivals", "League of legends", "Reading","Music creation"];
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Movie()
        {
            return View();
        }
        public IActionResult Colors()
        {
            ViewBag.MyColors = _myColors;

            return View();
        }
        public IActionResult Cities()
        {
            ViewBag.MyCities = _myCities;
            return View();
        }
        public IActionResult Hobbies()
        {
            ViewBag.MyHobbies = _myHobbies;
            return View();
        }
        public IActionResult Movies()
        {
            var movieList = BasicFunctions.GetAllMoviesWithDetails();
            return View(movieList);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
