using Identity.Data;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

      

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            this.db = db;

            _logger = logger;
        }

     
        [Authorize]
        public IActionResult Index()
        {
            var persons = db.Users.Where(a => a.Age < 100).ToList();

            if (User.Identity.IsAuthenticated)
            {

            }
            return View();
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
